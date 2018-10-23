using Restneer.Core.Application.Cache;
using Restneer.Core.Domain.Logic;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Core.Application.Boot
{
    public class RestneerCacheBoot
    {
        readonly ApiResourceRouteLogic _apiResourceRouteLogic;

        public RestneerCacheBoot(ApiResourceRouteLogic apiResourceRouteLogic)
        {
            _apiResourceRouteLogic = apiResourceRouteLogic;
        }

        public async void Load()
        {
            try
            {
                var queryParamApiResourceRoute = new QueryParamValueObject<ApiResourceRouteEntity>();
                RestneerCache.ApiResourceRoutes =
                    await _apiResourceRouteLogic.List(queryParamApiResourceRoute);
            }
            catch
            {
                throw;
            }
        }
    }
}
