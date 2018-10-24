using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Restneer.Core.Infrastructure.Repository;
using Restneer.Core.Infrastructure.Utility;

namespace Restneer.Core.Domain.Logic
{
    public class ApiUserLogic : AbstractLogic, 
                                IApiUserLogic
    {
        readonly IApiUserRepository _apiUserRepository;
        readonly JwtUtility _jwtUtility;
        readonly Sha256Utility _sha256Utility;

        public ApiUserLogic(
            IApiUserRepository apiUserRepository,
            JwtUtility jwtUtility,
            Sha256Utility sha256Utility,
            IConfiguration configuration)
            : base(configuration)
        {
            _apiUserRepository = apiUserRepository;
            _jwtUtility = jwtUtility;
            _sha256Utility = sha256Utility;
        }

        public async Task<string> GetJwtToken(string email, string password)
        {
            try
            {
                var encryptedPassword = _sha256Utility.Encrypt(password);
                var apiUser = await _apiUserRepository.Authenticate(email, encryptedPassword);
                if(apiUser == null) {
                    throw new Exception("Invalid credentials!");
                }
                var token = _jwtUtility.GenerateJwt(
                    Configuration.GetSection("Server:Jwt:SecretKey").Value,
                    Configuration.GetSection("Server:Jwt:Audience").Value,
                    apiUser.Id.ToString(),
                    apiUser.ApiRole.Id.ToString(),
                    apiUser.Email,
                    Convert.ToInt32(Configuration.GetSection("Server:Jwt:DaysToExpire").Value)
                );
                return token.RawData;
            }
            catch
            {
                throw;
            }
        }
    }
}
