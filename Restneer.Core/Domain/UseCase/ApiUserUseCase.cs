using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Domain.Logic;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Domain.UseCase
{
    public class ApiUserUseCase : IApiUserUseCase
    {
        readonly IApiUserLogic _apiUserLogic;
        public IResultFlowFactory ResultFlowFactory { get; set; }
        public ILogger<IApiUserUseCase> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiUserUseCase(
            IApiUserLogic apiUserLogic,
            IResultFlowFactory resultFlowFactory,
            ILogger<IApiUserUseCase> logger, 
            IConfiguration configuration)
        {
            _apiUserLogic = apiUserLogic;
            ResultFlowFactory = resultFlowFactory;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<ResultFlow<string>> Authenticate(string email, string password)
        {
            try {
                var getJwtTokenResultFlow = await _apiUserLogic.GetJwtToken(email, password);
                if (getJwtTokenResultFlow.IsExceptionWithoutResult()) {
                    return getJwtTokenResultFlow;
                }
                return ResultFlowFactory.Success<string>(getJwtTokenResultFlow.Result);
            } catch {
                throw;
            }
        }
    }
}
