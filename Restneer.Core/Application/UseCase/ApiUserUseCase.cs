using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Domain.Logic;

namespace Restneer.Core.Application.UseCase
{
    public class ApiUserUseCase : IApiUserUseCase
    {
        public ILogger<IApiUserUseCase> Logger { get; set; }
        public IConfiguration Configuration { get; set; }
        readonly IApiUserLogic _apiUserLogic;

        public ApiUserUseCase(IApiUserLogic apiUserLogic, ILogger<IApiUserUseCase> logger, IConfiguration configuration)
        {
            _apiUserLogic = apiUserLogic;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<string> Authenticate(string email, string password)
        {
            try {
                Logger.LogDebug("Getting jwt token");
                return await _apiUserLogic.GetJwtToken(email, password);
            } catch {
                throw;
            }
        }
    }
}
