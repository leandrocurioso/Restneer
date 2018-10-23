using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Restneer.Core.Infrastructure.Utility
{
    public class JwtUtility
    {
        public virtual JwtSecurityToken GenerateJwt(string secretKey, string audience, string issuer, string role, string email, int daysToExpire)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(secretKey);
                var signingKey = new SymmetricSecurityKey(key);
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var token = handler.CreateJwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    expires: DateTime.UtcNow.AddDays(daysToExpire),
                    subject: new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Role, role),
                        new Claim(ClaimTypes.Email, email)
                    }),
                    signingCredentials: signingCredentials);
                return token;
            }
            catch
            {
                throw;
            }
        }
    }
}
