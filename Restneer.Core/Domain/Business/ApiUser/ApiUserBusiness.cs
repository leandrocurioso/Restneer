using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Restneer.Core.Infrastructure.Repository.ApiUser;
using Restneer.Core.Infrastructure.Utility.Sha256;

namespace Restneer.Core.Domain.Business.ApiUser
{
    public class ApiUserBusiness : AbstractBusiness, 
                                   IApiUserBusiness
    {
        readonly IApiUserRepository _apiUserRepository;
        readonly ISha256Utility _sha256Utility;

        public ApiUserBusiness(
            IApiUserRepository apiUserRepository,
            ISha256Utility sha256Utility,
            IConfiguration configuration)
            : base(configuration)
        {
            _apiUserRepository = apiUserRepository;
            _sha256Utility = sha256Utility;
        }

        public async Task<string> GetJwtToken(string email, string password)
        {
            try {
                var handler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes("leandromoreiracuriosodeoliveira");
                var signingKey = new SymmetricSecurityKey(key);
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var encryptedPassword = _sha256Utility.Encrypt(password);
                var apiUser = await _apiUserRepository.Authenticate(email, encryptedPassword);
                var token = handler.CreateJwtSecurityToken(
                    issuer: apiUser.Id.ToString(),
                    audience: "http://localhost",
                    expires: DateTime.UtcNow.AddDays(10),
                    subject: new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Role, apiUser.ApiRole.Id.ToString()),
                        new Claim(ClaimTypes.Email, apiUser.Email)
                    }),
                    signingCredentials: signingCredentials);
                    
                return await Task.FromResult(token.RawData);
            }
            catch {
                throw;
            }
        }
    }
}
