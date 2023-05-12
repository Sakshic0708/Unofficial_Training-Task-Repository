//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using System.Web.Mvc;

//namespace DataAccessLayer.Attributes
//{
//    public class CustomAuthorizeAttribute : AuthorizeAttribute
//    {
//        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
//        {
//            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
//            {
//                base.HandleUnauthorizedRequest(filterContext);
//            }
//            else
//            {
//                filterContext.Result = new RedirectToActionResult("AccessDenied","Customer",null)
//            }
//        }
//    }

//}
