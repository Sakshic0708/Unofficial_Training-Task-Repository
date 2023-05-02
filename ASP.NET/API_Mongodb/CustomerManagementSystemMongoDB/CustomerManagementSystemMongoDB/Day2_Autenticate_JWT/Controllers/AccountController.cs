using CustomerDatas;
using Day2_Autenticate_JWT.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace customerManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
   
    public class AccountController : ControllerBase
    {

        public string userFilePath = @"D:\\Sakshi Chauhan\\CreateAPI_.Net\\Day-2_Authentication_JWT\\Day2_Autenticate_JWT\\Day2_Autenticate_JWT\\Data\\UserData.json";
        // POST: api/<AccountController>
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(User model)
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                model.Id = Guid.NewGuid();
                var USerobj = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                var UserFile = System.IO.File.ReadAllText(userFilePath);
                var objUsers = new List<User>();
                if (!string .IsNullOrEmpty(UserFile))
                {

                    objUsers = Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(UserFile);
                    if (objUsers != null && objUsers.Count > 0)
                    {
                        if(objUsers.Where(p => p.Email == model.Email).Count() > 0)
                        {
                            objResponse.Message = "Email is ALready Exists";
                        }
                        else
                        {
                            CreateUser(model, objResponse, objUsers);

                        }
                    }
                }
                else
                {
                    CreateUser(model, objResponse, objUsers);
                }


            }
            catch(System.Exception ex)
            {
                objResponse.Message = ex.Message;
            }

            return Ok(objResponse);
        }

        private void CreateUser(User model, CommonJsonResponse objResponse, List<User> objUsers)
        {
            objUsers.Add(model);
            System.IO.File.WriteAllText(userFilePath, Newtonsoft.Json.JsonConvert.SerializeObject(objUsers));
            objResponse.Status = 1;
            objResponse.Message = "Registered Successfully";
        }

        // POST api/<AccountController>
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(Login model)
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
                    if (objuser != null && !string.IsNullOrEmpty(objuser.Id.ToString()))
                    {
                        objResponse.access_tocken = Day2_Autenticate_JWT.Common.CommonMethod.GenerateJSONWebToken(objuser);
                        objResponse.Status = 1;
                        objResponse.tocken_type = "Bearer";
                        objResponse.data = objuser;
                        objResponse.Message = "login successfully.";
                    }
                    else
                    {
                        objResponse.Status = 0;
                        objResponse.Message = "Invalid Email or Password"; 
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
