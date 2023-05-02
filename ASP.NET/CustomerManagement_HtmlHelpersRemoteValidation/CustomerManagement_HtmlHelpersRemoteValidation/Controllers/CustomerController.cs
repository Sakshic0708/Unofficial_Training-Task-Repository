using DataAccessLayer.Interface;
using DataAccessLayer.Services;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using SharpCompress.Common;
using CommonLibrary;
using Microsoft.AspNetCore.Authorization;

namespace CustomerManagement_HtmlHelpersRemoteValidation.Controllers
{

    public class CustomerController : Controller
    {
        CustomerRepository customerRepository = new CustomerRepository();
        ICustomerInterface _customerservices;

        public string FilePath { get; private set; }

        public CustomerController(ICustomerInterface Customerservices)
        {
            _customerservices = Customerservices;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var customers = _customerservices.GetCustomers();
            return View(customers);
        }


        // GET: CustomerController/Create
        public ActionResult Create()
        {

            Customer model = new Customer();
            model.Id = new ObjectId();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    if (Request.Form.Files.Count > 0)
                    {

                        var file = Request.Form.Files[0];
                        var Extension = Path.GetExtension(Request.Form.Files[0].FileName);
                        var StoredFileName = "CustomerFile_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + Extension;
                        var FilePath = AppConfiguration.FilePath + StoredFileName;
                        customer.FilePath = StoredFileName;
                        using (var stream = new FileStream(FilePath, FileMode.Create))
                        {   
                            file.CopyTo(stream);
                        }
                        _customerservices.AddCustomer(customer);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating customer: {ex.Message}");
                }
                return View(customer);
            }
            return View(customer);

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetCustomerDetails(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                {
                    return BadRequest();
                }

                var customer = _customerservices.GetCustomerById(objectId);
                if (customer == null)
                {
                    return NotFound();
                }

                return PartialView("_CustomerDetail", customer);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error getting customer details: {ex.Message}");
                return BadRequest();
            }
        }
        [AllowAnonymous]
        public ActionResult ExportCustomersCSV()
        {
            var objCustomers  = _customerservices.GetCustomers();
            var FileName =  Guid.NewGuid() + "Export.csv";
            var FilePath = "D:\\Sakshi Chauhan\\CreateAPI_.Net\\CustomerManagement_HtmlHelpersRemoteValidation\\CustomerManagement_HtmlHelpersRemoteValidation\\wwwroot\\" + FileName;
            CommonFunctions.WriteCSV<Customer>(objCustomers, FilePath);

            return File(FileName, "text/csv");

        }
        // GET: CustomerController/Edit/5
        public ActionResult Edit(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                {
                    return BadRequest();
                }
                var customer = _customerservices.GetCustomerById(objectId);
                if (customer == null)
                {
                    return NotFound();
                }
                return View(customer);
            }
            catch (Exception ex)
            {
                return View("Error", new { message = ex.Message });
            }
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Customer customer)
        {
            try
            {
                var objectId = new ObjectId(id);
                customer.Id = objectId;
                _customerservices.UpdateCustomer(customer);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new { message = ex.Message });
            }


        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(string id)
        {
            try
            {
                if (!ObjectId.TryParse(id, out ObjectId objectId))
                {
                    return BadRequest();
                }
                var customer = _customerservices.GetCustomerById(objectId);
                return View(customer);
            }
            catch (Exception ex)
            {
                return View("Error", new { message = ex.Message });
            }
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                _customerservices.DeleteCustomer(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", new { message = ex.Message });
            }
        }

        public IActionResult CheckExistingEmail(string email)
        {
            var customer = _customerservices.GetEmailCustomer(email);

            if (customer.Count == 0)
            {
                return Json(true);
            }
            else
            {
                return Json($"Email {email} is already in use");
            }
        }


    }
}
