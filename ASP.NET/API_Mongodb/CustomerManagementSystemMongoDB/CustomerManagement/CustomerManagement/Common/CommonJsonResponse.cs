using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System;

namespace CustomerManagement.Common
{
    public class CommonJsonResponse
    {
        public int Status { get; set; }
        //1=success,2=warining,0=failed
        public string Message { get; set; }
        public dynamic data { get; set; }
    }

    public class LoginResponse: CommonJsonResponse
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
    }


}
