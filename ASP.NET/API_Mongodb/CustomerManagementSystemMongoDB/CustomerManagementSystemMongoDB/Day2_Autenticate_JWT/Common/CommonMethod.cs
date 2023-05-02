using CustomerDatas;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace Day2_Autenticate_JWT.Common
{
    public static class CommonMethod
    {
        public static string GenerateJSONWebToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuwASADASDADASDSADSDASDASDASDSDASDA1qvUC5dcGt3SNM"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"{user.Email}"),
                new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var tokeOptions = new JwtSecurityToken(
                issuer: "https://localhost:44350",
                audience: "https://localhost:44350",
                claims: authClaims,
                expires: DateTime.UtcNow.AddMinutes(5),
                signingCredentials: signinCredentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }
    }
}
