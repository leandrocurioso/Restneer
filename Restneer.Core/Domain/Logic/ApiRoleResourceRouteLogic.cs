using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using Restneer.Core.Infrastructure.Repository;

namespace Restneer.Core.Domain.Logic
{
    public class ApiRoleResourceRouteLogic : IApiRoleResourceRouteLogic
    {
        readonly IApiRoleResourceRouteRepository _apiRoleResourceRouteRepository;
        public ILogger<IApiRoleResourceRouteLogic> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiRoleResourceRouteLogic(
            IApiRoleResourceRouteRepository apiRoleResourceRouteRepository,
            ILogger<IApiRoleResourceRouteLogic> logger,
            IConfiguration configuration
        )
        {
            _apiRoleResourceRouteRepository = apiRoleResourceRouteRepository;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<IEnumerable<ApiRoleResourceRouteEntity>> List(QueryParamValueObject<ApiRoleResourceRouteEntity> model)
        {
            try
            {
                return await _apiRoleResourceRouteRepository.List(model);
            }
            catch
            {
                throw;
            }
        }
    }
}
