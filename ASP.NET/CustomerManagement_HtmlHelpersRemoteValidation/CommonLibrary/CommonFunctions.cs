using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public static class CommonFunctions
    {
        public static void WriteCSV<T>(List<T> items, string path)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            using (var writer = new StreamWriter(path, false)) // Set append parameter to false
            {
                writer.WriteLine(string.Join(", ", props.Select(p => p.Name)));

                foreach (var item in items)
                {
                    writer.WriteLine(string.Join(", ", props.Select(p => p.GetValue(item, null))));
                }
            }
        }

        public static void CreateCookie(IHttpContextAccessor _httpContextAccessor, string Name, string value, CookieOptions options)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(Name, value, options);
        }
        //public static void DeleteCookie(IHttpContextAccessor _httpContextAccessor, string Name)
        //{
        //    CookieOptions options = new CookieOptions();
        //    options.Expires = DateTime.Now.AddSeconds(-2);
        //    _httpContextAccessor.HttpContext.Response.Cookies.Append(Name, "", options);
        //}
        public static string ReadCookie(IHttpContextAccessor _httpContextAccessor, string Name)
        {
            string objCookie = _httpContextAccessor.HttpContext.Request.Cookies[Name];

            return objCookie;
        }
    }
}
