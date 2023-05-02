using CustomerManagement.Common;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        public string userFilePath = @"D:\\\\DEmo\\\\CustomerManagement\\\\DataAccess\\\\Data\\\\Users.json";

        // POST api/<AccountController>
        [HttpPost]
        [Route("register")]

        public ActionResult register(User model)
        {
            var objResponse = new CommonJsonResponse();
            try
            {

                model.userId = Guid.NewGuid();
                var objUser = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var userDb = System.IO.File.ReadAllText(userFilePath);
                var objUsers = new List<User>();
                if (!string.IsNullOrEmpty(userDb))
                {
                    objUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(userDb);

                    if (objUsers != null && objUsers.Count > 0)
                    {
                        if (objUsers.Where(p => p.Email == model.Email).Count() > 0)
                        {
                            objResponse.Message = "email is already exists";
                        }
                        else
                        {
                            Createuser(model, objResponse, objUsers);
                        }
                    }
                }
                else
                {
                    Createuser(model, objResponse, objUsers);
                }
            }
            catch (System.Exception e)
            {
                objResponse.Message = e.Message;

            }
            return Ok(objResponse);
        }

        private void Createuser(User model, CommonJsonResponse objResponse, List<User> objUsers)
        {
            //TODO: add new user in database
            objUsers.Add(model);
            //write file or udpate file.
            System.IO.File.WriteAllText(userFilePath, Newtonsoft.Json.JsonConvert.SerializeObject(objUsers));
            objResponse.Status = 1;
            objResponse.Message = "register successfully.";
        }

        [HttpPost]
        [Route("login")]
        public ActionResult login(Login model)
        {
            var objResponse = new LoginResponse();
            try
            {
                var userDb = System.IO.File.ReadAllText(userFilePath);
                var objUsers = new List<User>();
                if (!string.IsNullOrEmpty(userDb))
                {
                    objUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(userDb);
                    var objuser = objUsers.Where(p => p.Email == model.Email && p.Password == model.Password).FirstOrDefault();
                    if (objuser != null &&!string.IsNullOrEmpty(objuser.userId.ToString()))
                    {
                        //Generate user token.
                        objResponse.access_token=CustomerManagement.Common.CommonMethods.GenerateJSONWebToken(objuser);
                        objResponse.Status = 1;
                        objResponse.token_type = "Bearer";    
                        objResponse.data=objuser;
                        objResponse.Message = "login successfully.";
                    }
                    else
                    {
                        //TODO : send error message to user.
                    }
                }
            }
            catch (System.Exception e)
            {
                objResponse.Message = e.Message;

            }
            return Ok(objResponse);
        }
    }
}
