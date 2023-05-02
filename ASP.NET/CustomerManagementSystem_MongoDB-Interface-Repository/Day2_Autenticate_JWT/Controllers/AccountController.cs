using MongoDBInterfaceRepository.Common;
using DataAccess.Services;
using DnsClient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonLibrary;
using DataAccess.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day2MongoDBInterfaceRepository.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class AccountController : ControllerBase
    {
        UserRepository userRepository = new UserRepository();
        [HttpPost]
        [Route("Register")]
        public ActionResult Register(User model)
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                var objUsers = userRepository.HasEmailRegistered(model.Email);
                if (objUsers.Count > 0)
                {
                    objResponse.Message = "Email is already exists.";
                }
                else
                {
                    userRepository.Add(model);
                    objResponse.Status = 1;
                    objResponse.Message = "Registered Successfully";
                }
            }
            catch (Exception ex)
            {
                objResponse.Message = ex.Message;
            }

            return Ok(objResponse);
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(Login model)
        {
            var objResponse = new LoginResponse();
            try
            {
                var objuser = userRepository.FindByEmailAndPassword(model.Email, model.Password);

                if (objuser != null && !string.IsNullOrEmpty(objuser.Id.ToString()))
                {
                    var Audiences = AppConfiguration.ValidAudiences;
                    var Users = AppConfiguration.ValidIssuers;
                    var Secret = AppConfiguration.SecretKey;
                    objResponse.access_tocken = MongoDBInterfaceRepository.Common.CommonMethod.GenerateJSONWebToken(objuser, Audiences, Users, Secret);

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
            catch (System.Exception e)
            {
                objResponse.Message = e.Message;

            }
            return Ok(objResponse);
        }
        [HttpGet]
        [Route("Profile")]
        //[Authorize(Roles = "Admin")]
        public ActionResult Profile()
        {
            var objResponse = new CommonJsonResponse();
            try
            {
                string authHeader = Request.Headers["Authorization"];
                authHeader = authHeader.Replace("Bearer", "").Trim();
                objResponse.Status = 1;
                objResponse.data = MongoDBInterfaceRepository.Common.CommonMethod.GetEmail(authHeader);
                objResponse.Message = "This User is Login Now";
            }
            catch(System.Exception e)
            {
                objResponse.Message = e.Message;
            }
            return Ok(objResponse );
        }
    }

}




