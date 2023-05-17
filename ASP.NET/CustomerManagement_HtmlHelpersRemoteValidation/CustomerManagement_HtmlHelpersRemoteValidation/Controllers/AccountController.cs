using CustomerManagement_HtmlHelpersRemoteValidation.Common;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Data;

namespace CustomerManagement_HtmlHelpersRemoteValidation.Controllers
{
   
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager { get; set; }
        private RoleManager<ApplicationRole> _roleManager { get; set; }
        private SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager) 
        {
            _userManager = userManager;
            this.signInManager = signInManager;
            _roleManager = roleManager;
        }
       public ActionResult Register()
        {
            var registerModel = new RegisterViewModel();
            //ViewBag.Roles = _roleManager.Roles.Select(p=> new SelectListItem { Text=p.Name,Value=p.Name}).ToList();
            return View(registerModel);
        }
         [HttpPost]
        public ActionResult Register(RegisterViewModel registerModel)
        {
            if(ModelState.IsValid)
            {
                var applicationuser = new ApplicationUser() {FirstName= registerModel.FirstName, LastName=registerModel.LastName,Address= registerModel.Address,City=registerModel.City,Email=registerModel.Email,PhoneNumber=registerModel.PhoneNumber,UserName= registerModel.Email};
                var objUser = _userManager.CreateAsync(applicationuser,registerModel.Password).Result;
              
                if (objUser.Succeeded)
                {
                    var result = _userManager.AddToRoleAsync(applicationuser, "Employee").Result;
                    ViewBag.Message = "User Created Cuccessfully";
                }
                 
                else
                {
                    foreach (IdentityError error in objUser.Errors)
                         ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                ViewBag.error = string.Join(";",ModelState.Values.SelectMany(x=> x.Errors).Select(x=>x.ErrorMessage));
            }
            //Selected item in dropdown list
            //ViewBag.Roles = _roleManager.Roles.Select(p => new SelectListItem { Text = p.Name, Value = p.Name }).ToList();
            return View(registerModel);
        }

        [AllowAnonymous]
        public ActionResult Login()  => View();

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel loginModel)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser objUser = _userManager.FindByEmailAsync(loginModel.Email).Result;
                if(objUser != null)
                {
                    var result = signInManager.PasswordSignInAsync(objUser, loginModel.Password,false,true).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                }
                ModelState.AddModelError(nameof(loginModel.Email), "Login Failed:Invalid Email Or Password");
            }
            else
            {                   
                ViewBag.error = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            }
            return View(loginModel); 
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles ="Admin")]                                                                                                               
        public ActionResult Users()
        {
            var registerModel =  _userManager.Users.ToList();
            ViewBag.Roles = _roleManager.Roles.ToList().Select(p=> new SelectListItem { Text=p.Name,Value=p.Id.ToString()}).ToList();
            return View(registerModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult ChangeRole(string Id, string role)
        {
            var objResponse = new CommonJsonResponse();

            var user = _userManager.FindByIdAsync(Id).Result;
            if (user == null)
            {
                return NotFound();
            }

            if (user.Roles != null && user.Roles.Count > 0)
            {
                user.Roles.Clear();
                _userManager.UpdateAsync(user);
            }

            var result = _userManager.AddToRoleAsync(user, role).Result;
            if (!result.Succeeded)
            {
                objResponse.Status = 0;
                objResponse.Message = "Role update failed";
                return Json(objResponse);
            }
            else
            {
                objResponse.Status = 1;
                objResponse.Message = "Role updated successfully";
                objResponse.data = role ;
                return Json(objResponse);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

  
