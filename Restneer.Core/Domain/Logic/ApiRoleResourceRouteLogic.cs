using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using Restneer.Core.Infrastructure.Repository;

namespace Restneer.Core.Domain.Logic
{
    public class ApiRoleResourceRouteLogic : AbstractLogic, 
                                             IApiRoleResourceRouteLogic
    {
        readonly IApiRoleResourceRouteRepository _apiRoleResourceRouteRepository;

        public ApiRoleResourceRouteLogic(IApiRoleResourceRouteRepository apiRoleResourceRouteRepository, IConfiguration configuration)
            : base(configuration)
        {
            _apiRoleResourceRouteRepository = apiRoleResourceRouteRepository;
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
