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
        readonly IApiRoleResourceRouteLogic _apiRoleResourceRouteLogic;
        const string ApiResourceRoutesKey = "RestneerCache.ApiResourceRoutes";
        const string ApiRoleResourceRoutesKey = "RestneerCache.ApiRoleResourceRoutes";

        public RestneerCacheService(
            ILogger<IRestneerCacheService> logger,
            IApiResourceRouteLogic apiResourceRouteLogic,
            IApiRoleResourceRouteLogic apiRoleResourceRouteLogic,
            IDatabase redisConnection
        )
        {
            _logger = logger;
            _redisConnection = redisConnection;
            _apiResourceRouteLogic = apiResourceRouteLogic;
            _apiRoleResourceRouteLogic = apiRoleResourceRouteLogic;
        }

        public async Task Load()
        {
            try
            {
                await SetApiResourceRoute();
                await SetApiRoleResourceRoute();
                return;
            }
            catch
            {
                throw;
            }
        }

        async Task SetApiRoleResourceRoute()
        {
            try
            {
                var queryParamApiRoleResourceRoute = new QueryParamValueObject<ApiRoleResourceRouteEntity>();
                var apiResourceRouteLogicResultFlow = await _apiRoleResourceRouteLogic.List(queryParamApiRoleResourceRoute);
                var jsonString = JsonConvert.SerializeObject(apiResourceRouteLogicResultFlow.Result);
                _redisConnection.StringSet(ApiRoleResourceRoutesKey, jsonString);
                _logger.LogInformation(jsonString);
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

        public IEnumerable<ApiRoleResourceRouteEntity> GetApRoleResourceRoute()
        {
            try {
                var apiRoleResourceRoutes = _redisConnection.StringGet(ApiRoleResourceRoutesKey);
                return JsonConvert.DeserializeObject<IEnumerable<ApiRoleResourceRouteEntity>>(apiRoleResourceRoutes);
            } catch {
                throw;
            }
        }
    }
}
