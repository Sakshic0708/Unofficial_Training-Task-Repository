using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace CustomerManagement_MVC.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository customerRepository = new CustomerRepository();
        ICustomerInterface _customerservices;
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

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: CustomerController/Create
        public ActionResult Create()
        {
            Customer model=new Customer();
            model.Id= new ObjectId();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer model)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    _customerservices.AddCustomer(model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating customer: {ex.Message}");
                }
            }

            return View(model);
        }


       
        // GET: CustomerController/Edit/5
        public ActionResult Edit(string id)
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



        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Customer customer)
        {
            var objectId = new ObjectId(id);

            customer.Id = objectId;
            _customerservices.UpdateCustomer(customer);
            return RedirectToAction("Index");

        }


        // GET: CustomerController/Delete/5
        public ActionResult Delete(string id)
        {
            if (!ObjectId.TryParse(id, out ObjectId objectId))
            {
                return BadRequest();
            }
            var customer = _customerservices.GetCustomerById(objectId);
            return View(customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            _customerservices.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}

