using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Restneer.Core.Domain.Logic;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Model.ValueObject;
using StackExchange.Redis;

namespace Restneer.Core.Infrastructure.Service
{
    public class RestneerCacheService : IRestneerCacheService
    {
        readonly IDatabase _redisConnection;
        readonly ILogger<IRestneerCacheService> _logger;
        readonly IApiResourceRouteLogic _apiResourceRouteLogic;
        const string ApiResourceRoutesKey = "RestneerCache.ApiResourceRoutes";

        public RestneerCacheService(
            ILogger<IRestneerCacheService> logger,
            IApiResourceRouteLogic apiResourceRouteLogic,
            IDatabase redisConnection
        )
        {
            _logger = logger;
            _redisConnection = redisConnection;
            _apiResourceRouteLogic = apiResourceRouteLogic;
        }

        public async Task Load()
        {
            try
            {
                await SetApiResourceRoute();
                return;
            }
            catch
            {
                throw;
            }
        }

        async Task SetApiResourceRoute()
        {
            try
            {
                var queryParamApiResourceRoute = new QueryParamValueObject<ApiResourceRouteEntity>();
                var apiResourceRouteLogicResultFlow = await _apiResourceRouteLogic.List(queryParamApiResourceRoute);
                var jsonString = JsonConvert.SerializeObject(apiResourceRouteLogicResultFlow.Result);
                _redisConnection.StringSet(ApiResourceRoutesKey, jsonString);
                _logger.LogInformation(jsonString);
                return;
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<ApiResourceRouteEntity> GetApiResourceRoute()
        {
            try
            {
                var apiResourceRoutes = _redisConnection.StringGet(ApiResourceRoutesKey);
                return JsonConvert.DeserializeObject<IEnumerable<ApiResourceRouteEntity>>(apiResourceRoutes);
            }
            catch
            {
                throw;
            }
        }
    }
}
