using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using DataAccess;
using CustomerManagement.Common;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using Newtonsoft.Json;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        // GET: api/<CustomerController>
        [HttpGet]
        public ActionResult Get(string name="")
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                //TODO
                //Customer Add in to list
                // Get customer
                // return all customer 
                //Read customer json
                //var objCustomer = System.IO.File.ReadAllText(@"D:\\DEmo\\CustomerManagement\\DataAccess\\Data\\customer.json");
                var objCustomer=new List<Customer>();
                for(var i=0; i < 10; i++)
                {
                    objCustomer.Add(new Customer()
                    {
                        Email = "jeshal_" + i + "@getnada.com",
                        Name = "jeshal" + i,
                        PhoneNumber = "8866625004" + i
                    });
                }
                if(!string.IsNullOrEmpty(name))
                objCustomer=objCustomer.Where(p => p.Name.ToLower() == name.ToLower()).ToList();

                objResponse.data = objCustomer;//JsonConvert.DeserializeObject<Customer>(objCustomer); 
                objResponse.Message = "record found successfully.";
                objResponse.Status = 1;
            }
            catch (System.Exception ex)
            {
                objResponse.Message = ex.Message;
                //Add log for error
            }


            return Ok(objResponse);
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var objResponse = new CommonJsonResponse();
            try
            {


            }
            catch (System.Exception ex)
            {

                //Add log for error
            }

            return Ok(objResponse);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public ActionResult Post(Customer modal)
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                objResponse.Status= 1;
                objResponse.Message = "record created";
                objResponse.data = modal;

            }
            catch (System.Exception ex)
            {

                //Add log for error
            }

            return Ok(objResponse);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            var objResponse = new CommonJsonResponse();
            try
            {


            }
            catch (System.Exception ex)
            {

                //Add log for error
            }
            return Ok(objResponse);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var objResponse = new CommonJsonResponse();
            try
            {


            }
            catch (System.Exception ex)
            {

                //Add log for error
            }
            return Ok(objResponse);
        }
    }
}
