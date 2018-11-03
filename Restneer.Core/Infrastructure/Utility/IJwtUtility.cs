using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Restneer.Core.Infrastructure.Utility
{
    public interface IJwtUtility
    {
        JwtSecurityToken EncodeJwt(string secretKey, string audience, string issuer, string role, string email, int daysToExpire);
        JwtSecurityToken DecodeJwt(string encodedToken);
        bool ValidateJwt(string encodedToken, string secretKey, string audience, string issuer);
    }
}