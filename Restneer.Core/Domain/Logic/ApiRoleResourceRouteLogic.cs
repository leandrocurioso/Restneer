using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Repository;
using Restneer.Core.Infrastructure.Model.ValueObject;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Domain.Logic
{
    public class ApiRoleResourceRouteLogic : IApiRoleResourceRouteLogic
    {
        readonly IApiRoleResourceRouteRepository _apiRoleResourceRouteRepository;
        public IResultFlowFactory ResultFlowFactory { get; set; }
        public ILogger<IApiRoleResourceRouteLogic> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiRoleResourceRouteLogic(
            IApiRoleResourceRouteRepository apiRoleResourceRouteRepository,
            IResultFlowFactory resultFlowFactory,
            ILogger<IApiRoleResourceRouteLogic> logger,
            IConfiguration configuration
        )
        {
            _apiRoleResourceRouteRepository = apiRoleResourceRouteRepository;
            ResultFlowFactory = resultFlowFactory;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<ResultFlow<IEnumerable<ApiRoleResourceRouteEntity>>> List(QueryParamValueObject<ApiRoleResourceRouteEntity> model)
        {
            try
            {
                var listResultFlow = await _apiRoleResourceRouteRepository.List(model);
                if (listResultFlow.IsException())
                    return ResultFlowFactory.Exception<IEnumerable<ApiRoleResourceRouteEntity>>(listResultFlow.Message);
                return ResultFlowFactory.Success<IEnumerable<ApiRoleResourceRouteEntity>>(listResultFlow.Result);
            }
            catch
            {
                throw;
            }
        }
    }
}
