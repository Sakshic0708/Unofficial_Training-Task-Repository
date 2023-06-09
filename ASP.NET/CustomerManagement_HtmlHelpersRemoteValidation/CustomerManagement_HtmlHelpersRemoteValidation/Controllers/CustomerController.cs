﻿using CommonLibrary;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SharpCompress.Common;

namespace CustomerManagement_HtmlHelpersRemoteValidation.Controllers
{

    public class CustomerController : Controller
    {
        CustomerRepository customerRepository = new CustomerRepository();
        ICustomerInterface _customerservices;
        public string FilePath { get; private set; }
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CustomerController(ICustomerInterface Customerservices, IHttpContextAccessor httpContextAccessor)
        {
            _customerservices = Customerservices;
            this._httpContextAccessor = httpContextAccessor;
        }

        //// GET: CustomerController
        //public ActionResult Index()
        //{
        //    var customers = _customerservices.GetCustomers();
        //    return View(customers);
        //}
        [Authorize(Roles ="Editor,Admin")]
        // GET: CustomerController/Create
        public ActionResult Create()
        {
            Customer ObjCustomer = new Customer();
            ObjCustomer.Id = new ObjectId();
            return View(ObjCustomer);
        }
        [Authorize(Roles = "Editor,Admin")]
        [HttpPost]
        public ActionResult Create(Customer customerModel)
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
                        customerModel.FilePath = StoredFileName;
                        using (var stream = new FileStream(FilePath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        _customerservices.AddCustomer(customerModel);
                    }
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error creating customer: {ex.Message}");
                }
                return View(customerModel);
            }
            return View(customerModel);

        }
        [Authorize(Roles = "Editor,Admin")]
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
        public ActionResult ExportCustomersCSV()
        {
            try
            {
                var objCustomers = _customerservices.GetCustomers();
                var FileName = "Export.csv";
                var PathCSV =  AppConfiguration.CSVFilePath + FileName;
                CommonFunctions.WriteCSV(objCustomers, PathCSV);
                byte[] fileBytes = System.IO.File.ReadAllBytes(PathCSV);
                return File(fileBytes, "text/csv", FileName);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }


        [Authorize(Roles = "Editor,Admin")]
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
        [Authorize(Roles = "Editor,Admin")]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(string id, Customer customerModel)
        {
            try
            {
                var objectId = new ObjectId(id);

                if (ModelState.IsValid)
                {
                    if (Request.Form.Files.Count > 0)
                    {
                        //Delete the existing file if it exists
                        if (!string.IsNullOrEmpty(customerModel.FilePath))
                        {
                            var existingFilePath = AppConfiguration.FilePath + customerModel.FilePath;
                            if (System.IO.File.Exists(existingFilePath))
                            {
                                System.IO.File.Delete(existingFilePath);
                            }
                        }
                        var File = Request.Form.Files[0];
                        var Extension = Path.GetExtension(Request.Form.Files[0].FileName);
                        var StoredFileName = "CustomerFile_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + "_" + Extension;
                        var FilePath = AppConfiguration.FilePath + StoredFileName;

                        using (var stream = new FileStream(FilePath, FileMode.Create))
                        {
                            File.CopyTo(stream);
                            File.CopyTo(stream);
                        }
                        customerModel.FilePath = StoredFileName;
                    }

                    customerModel.Id = objectId;
                    _customerservices.UpdateCustomer(customerModel);

                    return RedirectToAction("Index");
                }
                else
                {
                    return View(customerModel);
                }
            }
            catch (Exception ex)
            {
                return View("Error", new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Editor,Admin")]
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
        [Authorize(Roles = "Editor,Admin")]
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
            [Authorize(Roles = "Employee,Editor,Admin")]
            public ActionResult Index(string search, int page = 1, string sortby = "Name", string orderby = "asc")
            {
                var cookie = Request.Cookies["search"];
                if (!string.IsNullOrEmpty(cookie) && string.IsNullOrEmpty(search))
                {
                    search = cookie;
                }

                var objCustomers = _customerservices.SearchCustomer(search, sortby, orderby, page, pageSize: 3);

                ViewBag.search = search;
                ViewBag.sortby = sortby;
                //orderby = (orderby == "asc" ? "desc" : "asc");
                ViewBag.orderby = orderby;

                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(30);

                if (search != null && search.Length > 0)
                {
                    CommonFunctions.CreateCookie(_httpContextAccessor, "search", search, options);
                }

                return View(objCustomers);
            }

        public ActionResult ReadCookies()
        {

            string objCookie = CommonFunctions.ReadCookie(_httpContextAccessor, "CustomerEmail");
            return Json(objCookie);
        }

        [HttpPost]
        public ActionResult CookieDelete()
        {
            //var cookie = Request.Cookies["search"];
            //CookieOptions options = new CookieOptions();
            //options.Expires = DateTime.Now.AddSeconds(-2);
            //_httpContextAccessor.HttpContext.Response.Cookies.Append("search", "", options);

            Response.Cookies.Delete("search");

            //return Json("Delete");
            return RedirectToAction("Index");
        }


        //public ActionResult AccessDenied()
        //{
        //    return View();
        //}

    }
}
