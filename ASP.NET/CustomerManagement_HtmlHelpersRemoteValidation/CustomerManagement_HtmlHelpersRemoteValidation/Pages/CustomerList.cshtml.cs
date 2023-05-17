using CommonLibrary;
using DataAccessLayer.Interface;
using DataAccessLayer.Models;
using DataAccessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web.Mvc;

namespace CustomerManagement_HtmlHelpersRemoteValidation.Pages
{
    public class CustomerListModel : PageModel
    {
        private readonly ICustomerInterface _customerservices;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerListModel(ICustomerInterface customerservices, IHttpContextAccessor httpContextAccessor)
        {
            _customerservices = customerservices;
            _httpContextAccessor = httpContextAccessor;
        }
        public CustomerPaging? CustomerPageList { get; set; }
      
        public IActionResult OnGet(string search, int page = 1, string sortby = "Name", string orderby = "asc")
        {
            var cookie = Request.Cookies["search"];
            if (!string.IsNullOrEmpty(cookie) && string.IsNullOrEmpty(search))
            {
                search = cookie;
            }

            var objCustomers = _customerservices.SearchCustomer(search, sortby, orderby, page, pageSize: 3);

            ViewData["search"] = search;
            ViewData["sortby"] = sortby;
            ViewData["orderby"] = orderby;

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(30);

            if (search != null && search.Length > 0)
            {
                CommonFunctions.CreateCookie(_httpContextAccessor, "search", search, options);
            }

            return Page();
        }

    }
}
