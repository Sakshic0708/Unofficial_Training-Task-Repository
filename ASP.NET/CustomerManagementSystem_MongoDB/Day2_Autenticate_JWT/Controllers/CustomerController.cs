
using DataAccess;
using DataAccess.Services;
using Day2_Autenticate_JWT.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace customerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerController : ControllerBase
    {
        CustomerRepository customerRepository = new CustomerRepository();

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var Objcustomers = customerRepository.GetCustomers();

                  objResponse.data = Objcustomers;
                  objResponse.Message = "Record found successfully.";
                  objResponse.Status = 1;

            }
            catch (System.Exception ex)
            {
                objResponse.Message = ex.Message;
                //Add log for error
            }

            return Ok(objResponse);
        }

        [HttpGet]
        [Route("GetName")]

        public ActionResult<IEnumerable<Customer>> Get(string name = "")
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var Objcustomers = customerRepository.GetNameCustomers(name);

                objResponse.data = Objcustomers;
                objResponse.Message = "Record Show successfully.";
                objResponse.Status = 1;
            }
            catch (System.Exception ex)
            {
                objResponse.Message = ex.Message;
            }

            return Ok(objResponse);
        }
        [HttpPost]
        public ActionResult Post(Customer customer)
        {
            var objResponse = new CommonJsonResponse();

            try
            {
                customerRepository.PostCustomers(customer);

                objResponse.data = customer;
                objResponse.Message = "Record Created successfully.";
                objResponse.Status = 1;

            }
            catch (System.Exception ex)
            {
                // Handle any errors and set the response message and status accordingly
                objResponse.Message = ex.Message;
                objResponse.Status = 0;
            }

            // Return the response as JSON
            return Ok(objResponse);
        }
        [HttpPut]
        public ActionResult Put(string name, [FromBody] Customer customer)
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var result = customerRepository.PutCustomers(name, customer);

                if (result.ModifiedCount > 0)
                {
                    objResponse.Message = "Records updated successfully.";
                    objResponse.Status = 1;
                }
                else
                {
                    objResponse.Message = "No customer found with the specified name.";
                    objResponse.Status = 0;
                }
            }
            catch (System.Exception ex)
            {
                objResponse.Message = ex.Message;
                //Add log for error
            }

            return Ok(objResponse);
        }

        [HttpDelete]
        public ActionResult Delete(string name)
        {
            var objResponse = new CommonJsonResponse();

            try
            {
                var Objcustomers = customerRepository.DeleteCustomers(name);
                objResponse.data = Objcustomers;
                objResponse.Message = "Record Deleted successfully.";
                objResponse.Status = 1;
            }
            catch (System.Exception ex)
            {
                objResponse.Message = ex.Message;
                objResponse.Status = 0;
                //Add log for error
            }

            return Ok(objResponse);
        }
    }
}
