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
        readonly IConnectionMultiplexer _redisConnection;
        readonly ILogger<IRestneerCacheService> _logger;
        readonly IApiResourceRouteLogic _apiResourceRouteLogic;

        public RestneerCacheService(
            ILogger<IRestneerCacheService> logger,
            IApiResourceRouteLogic apiResourceRouteLogic,
            IConnectionMultiplexer redisConnection
        )
        {
            _logger = logger;
            _redisConnection = redisConnection;
            _apiResourceRouteLogic = apiResourceRouteLogic;
        }

        public async void Load()
        {
            try
            {
                var clientRedis = _redisConnection.GetDatabase();
                var queryParamApiResourceRoute = new QueryParamValueObject<ApiResourceRouteEntity>();
                var apiResourceRouteLogicResultFlow = await _apiResourceRouteLogic.List(queryParamApiResourceRoute);
                clientRedis.StringSet("RestneerCache.ApiResourceRoutes", JsonConvert.SerializeObject(apiResourceRouteLogicResultFlow.Result));
                _logger.LogInformation(clientRedis.StringGet("RestneerCache.ApiResourceRoutes"));

            }
            catch
            {
                throw;
            }
        }
    }
}
