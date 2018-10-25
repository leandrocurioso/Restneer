using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using Restneer.Core.Infrastructure.Repository;

namespace Restneer.Core.Domain.Logic
{
    public class ApiResourceRouteLogic : IApiResourceRouteLogic
    {
        readonly IApiResourceRouteRepository _apiResourceRouteRepository;
        public ILogger<IApiResourceRouteLogic> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiResourceRouteLogic(
            IApiResourceRouteRepository apiResourceRouteRepository,
            ILogger<IApiResourceRouteLogic> logger,
            IConfiguration configuration
        )
        {
            _apiResourceRouteRepository = apiResourceRouteRepository;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<IEnumerable<ApiResourceRouteEntity>> List(QueryParamValueObject<ApiResourceRouteEntity> model)
        {
            try
            {
                return await _apiResourceRouteRepository.List(model);
            }
            catch
            {
                throw;
            }
        }
    }
}
