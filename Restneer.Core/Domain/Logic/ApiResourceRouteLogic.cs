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
    public class ApiResourceRouteLogic : IApiResourceRouteLogic
    {
        readonly IApiResourceRouteRepository _apiResourceRouteRepository;
        public IResultFlowFactory ResultFlowFactory { get; set; }
        public ILogger<IApiResourceRouteLogic> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiResourceRouteLogic(
            IApiResourceRouteRepository apiResourceRouteRepository,
            IResultFlowFactory resultFlowFactory,
            ILogger<IApiResourceRouteLogic> logger,
            IConfiguration configuration
        )
        {
            _apiResourceRouteRepository = apiResourceRouteRepository;
            ResultFlowFactory = resultFlowFactory;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<ResultFlow<IEnumerable<ApiResourceRouteEntity>>> List(QueryParamValueObject<ApiResourceRouteEntity> model)
        {
            try
            {
                var listResultFlow = await _apiResourceRouteRepository.List(model);
                if (listResultFlow.IsException())
                    return ResultFlowFactory.Exception<IEnumerable<ApiResourceRouteEntity>>(listResultFlow.Message);
                return ResultFlowFactory.Success<IEnumerable<ApiResourceRouteEntity>>(listResultFlow.Result);
            }
            catch
            {
                throw;
            }
        }
    }
}
