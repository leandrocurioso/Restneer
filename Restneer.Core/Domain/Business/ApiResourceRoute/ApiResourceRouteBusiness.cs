using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using Restneer.Core.Infrastructure.Repository.ApiResourceRoute;

namespace Restneer.Core.Domain.Business.ApiResourceRoute
{
    public class ApiResourceRouteBusiness : AbstractBusiness,
                                            IApiResourceRouteBusiness
    {
        readonly IApiResourceRouteRepository _apiResourceRouteRepository;

        public ApiResourceRouteBusiness(IApiResourceRouteRepository apiResourceRouteRepository, IConfiguration configuration)
            : base(configuration)
        {
            _apiResourceRouteRepository = apiResourceRouteRepository;
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
