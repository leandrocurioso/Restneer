using System.IdentityModel.Tokens.Jwt;

namespace Restneer.Core.Infrastructure.Utility
{
    public interface IJwtUtility
    {
        JwtSecurityToken GenerateJwt(string secretKey, string audience, string issuer, string role, string email, int daysToExpire);
    }
}