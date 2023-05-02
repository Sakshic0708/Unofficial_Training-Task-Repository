using DataAccess;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using DataAccess.Model;
using System.Linq;

namespace MongoDBInterfaceRepository.Common
{
    public static class CommonMethod
    {
        public static string GenerateJSONWebToken(User user, string audience, string issuer, string secret)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ByYM000OLlMQG6VVVp1OH7Xzyr7gHuwASADASDADASDSADSDASDASDASDSDASDA1qvUC5dcGt3SNM"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"{user.Email}"),
                new Claim(ClaimTypes.NameIdentifier, $"{user.Id}"),
                new Claim(ClaimTypes.Role, $"Admin"),
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
        public static string GetEmail(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokens = handler.ReadToken(token) as JwtSecurityToken;
            var objClaims = tokens.Claims.ToList();
            var Email = tokens.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name").Value;

            return Email;
        }

        public static string getRole(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokens = handler.ReadToken(token) as JwtSecurityToken;
            var Role = tokens.Claims.First(claim => claim.Type == "Role").Value;

            return Role;
        }

    }
}
