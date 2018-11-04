using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Restneer.Core.Infrastructure.Utility
{
    public class JwtUtility : IJwtUtility
    {
        public JwtSecurityToken EncodeJwt(string secretKey, string audience, string issuer, string role, string email, int daysToExpire)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(secretKey);
                var signingKey = new SymmetricSecurityKey(key);
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var token = handler.CreateJwtSecurityToken(
                    issuer,
                    audience,
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

        public JwtSecurityToken DecodeJwt(string encodedToken)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                return handler.ReadJwtToken(encodedToken);
            }
            catch
            {
                return null;
            }
        }

        public bool ValidateJwt(string encodedToken, string secretKey, string audience, string issuer)
        {
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(secretKey);
                var signingKey = new SymmetricSecurityKey(key);
                var tokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = signingKey,
                    ValidAudience = audience,
                    ValidIssuer = issuer
                };
                handler.ValidateToken(encodedToken, tokenValidationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
