using Restneer.Core.Domain.Logic;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Model.ValueObject;
using Restneer.Core.Infrastructure.Cache;
using Restneer.Core.Infrastructure.ResultFlow;
using System;

namespace Restneer.Core.Infrastructure.Service
{
    public class RestneerCacheService : IRestneerCacheService
    {
        readonly ApiResourceRouteLogic _apiResourceRouteLogic;
        public IResultFlowFactory ResultFlowFactory { get; set; }

        public RestneerCacheService(
            ApiResourceRouteLogic apiResourceRouteLogic,
            IResultFlowFactory resultFlowFactory
        )
        {
            _apiResourceRouteLogic = apiResourceRouteLogic;
            ResultFlowFactory = resultFlowFactory;
        }

        public async void Load()
        {
            try
            {
                var queryParamApiResourceRoute = new QueryParamValueObject<ApiResourceRouteEntity>();
                var apiResourceRouteLogicResultFlow = await _apiResourceRouteLogic.List(queryParamApiResourceRoute);
                if (apiResourceRouteLogicResultFlow.IsSuccessWithResult()) {
                    throw new Exception("Couldn't get list of [RestneerCacheService][ApiResourceRoutes]");
                }
                RestneerCache.ApiResourceRoutes = apiResourceRouteLogicResultFlow.Result;
            }
            catch
            {
                throw;
            }
        }
    }
}
