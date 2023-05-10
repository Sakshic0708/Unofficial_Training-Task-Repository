using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var model = new RegisterViewModel();
            ViewBag.Roles = _roleManager.Roles.Select(p=> new SelectListItem { Text=p.Name,Value=p.Name}).ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
            {
                var applicationuser = new ApplicationUser() {FirstName=model.FirstName, LastName=model.LastName,Address=model.Address,City=model.City,Email=model.Email,PhoneNumber=model.PhoneNumber,UserName=model.Email};
                var objUser = _userManager.CreateAsync(applicationuser,model.Password).Result;
                if (objUser.Succeeded)
                {
                    _userManager.AddToRoleAsync(applicationuser, model.RoleId);
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
            ViewBag.Roles = _roleManager.Roles.Select(p => new SelectListItem { Text = p.Name, Value = p.Name }).ToList();
            return View(model);
        }
        [AllowAnonymous]
        public ActionResult Login()  => View();
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser objUser = _userManager.FindByEmailAsync(model.Email).Result;
                if(objUser != null)
                {
                    var result = signInManager.PasswordSignInAsync(objUser,model.Password,false,true).Result;
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(nameof(model.Email), "Login Failed:Invalid Email Or Password");
            }
            else
            {
                ViewBag.error = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            }
            return View(model); 
        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Roles()
        {
            var objRoles = _roleManager.Roles.ToList();
            return View(objRoles);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole() => View();

        [HttpPost]
        public ActionResult CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var objRole = _roleManager.CreateAsync(new ApplicationRole { Name=model.Name,Description=model.Description }).Result;
                if (objRole.Succeeded)
                    ViewBag.Message = "Role Created Successfully";
                else
                {
                    foreach (IdentityError error in objRole.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                ViewBag.error = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            }
            return View(model);
        }
    }
}
