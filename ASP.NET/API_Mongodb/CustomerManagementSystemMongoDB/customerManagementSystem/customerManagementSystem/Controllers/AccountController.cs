using CustomerData;
using customerManagementSystem.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace customerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
        // GET: api/<AccountController>
        [HttpGet]
        [Route("Register")]
        public ActionResult Register(User model)
        {
            var objResponse = new CommonJsonResponse();
            try
            {

            }
            catch(System.Exception e)
            { 

            }
            

            return Ok(model);
        }

        // POST api/<AccountController>
        [HttpGet]
        [Route("Login")]
        public ActionResult Login(Login model)
        {

            return Ok(model);   
        }
    }
}
