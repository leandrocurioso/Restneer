using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using Restneer.Core.Infrastructure.Repository.ApiRoleResourceRoute;

namespace Restneer.Core.Domain.Business.ApiRoleResourceRoute
{
    public class ApiRoleResourceRouteBusiness : IApiRoleResourceRouteBusiness
    {
        readonly IApiRoleResourceRouteRepository _apiRoleResourceRouteRepository;

        public ApiRoleResourceRouteBusiness(IApiRoleResourceRouteRepository apiRoleResourceRouteRepository)
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
