using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Domain.Logic;

namespace Restneer.Core.Application.UseCase
{
    public class ApiUserUseCase : AbstractUseCase, 
                                  IApiUserUseCase
    {
        readonly IApiUserLogic _apiUserLogic;

        public ApiUserUseCase(ILogger<IApiUserUseCase> logger, IApiUserLogic apiUserLogic, IConfiguration configuration)
            :base(logger, configuration)
        {
            _apiUserLogic = apiUserLogic;
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
