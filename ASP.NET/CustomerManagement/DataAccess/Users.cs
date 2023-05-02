using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class User
    {
        public Guid userId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
