using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Repository;
using Restneer.Core.Infrastructure.ResultFlow;
using Restneer.Core.Infrastructure.Utility;

namespace Restneer.Core.Domain.Logic
{
    public class ApiUserLogic : IApiUserLogic
    {
        readonly IApiUserRepository _apiUserRepository;
        readonly IJwtUtility _jwtUtility;
        readonly ISha256Utility _sha256Utility;
        public IResultFlowFactory ResultFlowFactory { get; set; }
        public ILogger<IApiUserLogic> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiUserLogic(
            IApiUserRepository apiUserRepository,
            IJwtUtility jwtUtility,
            ISha256Utility sha256Utility,
            IResultFlowFactory resultFlowFactory,
            ILogger<IApiUserLogic> logger,
            IConfiguration configuration
        )
        {
            _apiUserRepository = apiUserRepository;
            _jwtUtility = jwtUtility;
            _sha256Utility = sha256Utility;
            ResultFlowFactory = resultFlowFactory;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<ResultFlow<string>> GetJwtToken(string email, string password)
        {
            try
            {
                var encryptedPassword = _sha256Utility.Encrypt(password);
                email = email.ToLower();
                var authenticateResultFlow = await _apiUserRepository.Authenticate(email, encryptedPassword);
                if (authenticateResultFlow.IsSuccessWithoutResult()) 
                {
                    return ResultFlowFactory.Exception<string>("Invalid credentials");
                }
                var apiUser = authenticateResultFlow.Result;
                var token = _jwtUtility.GenerateJwt(
                    Configuration.GetSection("Server:Jwt:SecretKey").Value,
                    Configuration.GetSection("Server:Jwt:Audience").Value,
                    apiUser.Id.ToString(),
                    apiUser.ApiRole.Id.ToString(),
                    apiUser.Email,
                    Convert.ToInt32(Configuration.GetSection("Server:Jwt:DaysToExpire").Value)
                );
                return ResultFlowFactory.Success<string>(token.RawData);
            }
            catch
            {
                throw;
            }
        }
    }
}
