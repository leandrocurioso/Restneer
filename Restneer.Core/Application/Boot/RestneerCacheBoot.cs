using Restneer.Core.Application.Cache;
using Restneer.Core.Domain.Business.ApiResourceRoute;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Core.Application.Boot
{
    public class RestneerCacheBoot : IRestneerCacheBoot
    {
        readonly IApiResourceRouteBusiness _apiResourceRouteBusiness;

        public RestneerCacheBoot(IApiResourceRouteBusiness apiResourceRouteBusiness)
        {
            _apiResourceRouteBusiness = apiResourceRouteBusiness;
        }

        public async void Load() 
        {
            try
            {
                var queryParamApiResourceRoute = new QueryParamValueObject<ApiResourceRouteEntity>();
                RestneerCache.ApiResourceRoutes = 
                    await _apiResourceRouteBusiness.List(queryParamApiResourceRoute);
            }
            catch 
            {
                throw;
            }
        }
    }
}
