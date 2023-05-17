using CustomerManagement_HtmlHelpersRemoteValidation.Common;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace CustomerManagement_HtmlHelpersRemoteValidation.Controllers
{
    public class RolesController : Controller
    {

        private UserManager<ApplicationUser> _userManager { get; set; }
        private RoleManager<ApplicationRole> _roleManager { get; set; }
        private SignInManager<ApplicationUser> signInManager;
        public RolesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            this.signInManager = signInManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var objRoles = _roleManager.Roles.ToList();
            return View(objRoles);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult CreateRole() => View();

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateRole(RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var objRole = _roleManager.CreateAsync(new ApplicationRole { Name = roleModel.Name, Description = roleModel.Description }).Result;
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
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();

            var model = new RoleViewModel
            {
                Name = role.Name,
                Description = role.Description
            };

            return View(model);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditRole(RoleViewModel roleModel, string Id)
        {
           
            if (ModelState.IsValid)
            {
                var role = _roleManager.FindByIdAsync(Id).Result;
                if (role == null)
                    return NotFound();

                role.Name = roleModel.Name;
                role.Description = roleModel.Description;
                role.Description = roleModel.Description;

                var result = _roleManager.UpdateAsync(role).Result;
                if (result.Succeeded)
                    ViewBag.Message = "Role Updated Successfully";
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            else
            {
                ViewBag.error = string.Join(";", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteRole(string Id)
        {
            var objResponse = new CommonJsonResponse();
            var role = _roleManager.FindByIdAsync(Id).Result;
            if (role != null)
            {
                var result = _roleManager.DeleteAsync(role).Result;
                if (result.Succeeded)
                {
                    objResponse.Status = 1;
                    objResponse.Message = "Role deleted successfully";
                }
                else
                {
                    objResponse.Status = 0;
                    objResponse.Message = "Failed to delete role";
                }
            }
            else
            {
                objResponse.Status = 404;
                objResponse.Message = "Role not found";
            }

            return Json(objResponse);
        }



    }
}
