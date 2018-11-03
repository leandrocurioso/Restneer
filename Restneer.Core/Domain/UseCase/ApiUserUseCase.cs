using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Domain.Logic;
using Restneer.Core.Domain.Model.Entity;
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

        public async Task<ResultFlow<string>> Authenticate(string email, string password, string audience)
        {
            try {
                var getJwtTokenResultFlow = await _apiUserLogic.GetJwtToken(email, password, audience);
                if (getJwtTokenResultFlow.IsException()) {
                    return ResultFlowFactory.Exception<string>(getJwtTokenResultFlow.Message);
                }
                return ResultFlowFactory.Success<string>(getJwtTokenResultFlow.Result);
            } 
            catch 
            {
                throw;
            }
        }

        public async Task<ResultFlow<ApiUserEntity>> Read(ApiUserEntity model)
        {
            try {
                var readResultFlow = await _apiUserLogic.Read(model);
                if (readResultFlow.IsException())
                {
                    return ResultFlowFactory.Exception<ApiUserEntity>(readResultFlow.Message);
                }
                return ResultFlowFactory.Success<ApiUserEntity>(readResultFlow.Result);
            } 
            catch 
            {
                throw;
            }
        }
    }
}
