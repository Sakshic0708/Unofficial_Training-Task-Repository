using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CustomerData;
using customerManagementSystem.Common;
using System.Xml.Linq;
using System.Net;
using System.Reflection;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace customerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<customerController>
        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var objCustomer = System.IO.File.ReadAllText(@"D:\\Sakshi Chauhan\\CreateAPI_.Net\\customerManagementSystem\\CustomerData\\Data\\Customer.json");
                var Objcustomers = JsonConvert.DeserializeObject<List<Customer>>(objCustomer);

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
        public ActionResult Get(string name = "")
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var objCustomer = System.IO.File.ReadAllText(@"D:\\Sakshi Chauhan\\CreateAPI_.Net\\customerManagementSystem\\CustomerData\\Data\\Customer.json");
                var Objcustomers = JsonConvert.DeserializeObject<List<Customer>>(objCustomer);

                if (!string.IsNullOrEmpty(name))
                {
                    Objcustomers = Objcustomers.Where(p => p.Customername.ToLower().Contains(name.ToLower())).ToList();
                }
                objResponse.data = Objcustomers;
                objResponse.Message = "Record Show successfully.";
                objResponse.Status = 1;


            }
            catch (System.Exception ex)
            {
                objResponse.Message = ex.Message;
                //Add log for error
            }

            return Ok(objResponse);
        }
        [HttpPost]
        public ActionResult Post(Customer customer)
        {
            var objResponse = new CommonJsonResponse();

            try
            {
                objResponse.data = customer;
                objResponse.Message = "Record Created successfully.";
                objResponse.Status = 1;

                // Read the existing data from the JSON file
                var objCustomer = System.IO.File.ReadAllText(@"D:\\Sakshi Chauhan\\CreateAPI_.Net\\customerManagementSystem\\CustomerData\\Data\\Customer.json");
                var Objcustomers = JsonConvert.DeserializeObject<List<Customer>>(objCustomer);

                // Add the new customer to the list of existing customers
                Objcustomers.Add(customer);

                // Serialize the updated list of customers to JSON
                var updatedJsonData = JsonConvert.SerializeObject(Objcustomers, Formatting.Indented);

                // Write the updated JSON data back to the file
                System.IO.File.WriteAllText(@"D:\\Sakshi Chauhan\\CreateAPI_.Net\\customerManagementSystem\\CustomerData\\Data\\Customer.json", updatedJsonData);


            }
            catch (Exception ex)
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
                // Read the customer data from the JSON file
                var objCustomer = System.IO.File.ReadAllText(@"D:\\Sakshi Chauhan\\CreateAPI_.Net\\customerManagementSystem\\CustomerData\\Data\\Customer.json");
                var Objcustomers = JsonConvert.DeserializeObject<List<Customer>>(objCustomer);

                // Filter the customers based on the customer name provided in the parameter
                var CustomerUpdate = Objcustomers.FirstOrDefault(c => c.Customername.ToLower() == name.ToLower());

                // If any customers are found with the specified name, update their information
                if (CustomerUpdate != null)
                {

                    CustomerUpdate.Customername = customer.Customername;
                    CustomerUpdate.Email = customer.Email;
                    CustomerUpdate.Phoneno = customer.Phoneno;
                    CustomerUpdate.Address = customer.Address;


                    // Serialize the updated customers list to JSON
                    var updatedCustomersJson = JsonConvert.SerializeObject(Objcustomers);
                    // Write the JSON string back to the file
                    System.IO.File.WriteAllText(@"D:\\Sakshi Chauhan\\CreateAPI_.Net\\customerManagementSystem\\CustomerData\\Data\\Customer.json", updatedCustomersJson);

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
                var objCustomer = System.IO.File.ReadAllText(@"D:\\Sakshi Chauhan\\CreateAPI_.Net\\customerManagementSystem\\CustomerData\\Data\\Customer.json");
                var Objcustomers = JsonConvert.DeserializeObject<List<Customer>>(objCustomer);

                var CustomerDelete = Objcustomers.FirstOrDefault(c => c.Customername.ToLower() == name.ToLower());
                if (CustomerDelete != null)
                {
                    Objcustomers.Remove(CustomerDelete);

                    // Serialize the updated customers list to JSON
                    var DeletedJsonFile = JsonConvert.SerializeObject(Objcustomers);
                    // Write the JSON string back to the file
                    System.IO.File.WriteAllText(@"D:\\Sakshi Chauhan\\CreateAPI_.Net\\customerManagementSystem\\CustomerData\\Data\\Customer.json", DeletedJsonFile);

                    objResponse.data = DeletedJsonFile;
                    objResponse.Message = "Records Deleted successfully.";
                    objResponse.Status = 1;
                }
                else
                {
                    objResponse.Message = "Data Not Found.";
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


    }
}
