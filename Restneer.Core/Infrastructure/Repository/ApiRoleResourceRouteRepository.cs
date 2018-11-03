using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Dapper;
using Restneer.Core.Infrastructure.Model.ValueObject;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Infrastructure.ResultFlow;
using System;

namespace Restneer.Core.Infrastructure.Repository
{
    public class ApiRoleResourceRouteRepository : IApiRoleResourceRouteRepository
    {
        readonly IDbConnection _connection;
        public IResultFlowFactory ResultFlowFactory { get; set; }
        public ILogger<IApiRoleResourceRouteRepository> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiRoleResourceRouteRepository(
            IDbConnection connection,
            IResultFlowFactory resultFlowFactory,
            ILogger<IApiRoleResourceRouteRepository> logger,
            IConfiguration configuration
        )
        {
            _connection = connection;
            ResultFlowFactory = resultFlowFactory;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<ResultFlow<IEnumerable<ApiRoleResourceRouteEntity>>> List(QueryParamValueObject<ApiRoleResourceRouteEntity> model)
        {
            try
            {
                var sql = @"SELECT *
                                FROM api_role_resource_route 
                            INNER JOIN api_resource_route ON api_resource_route.id = api_role_resource_route.api_resource_route_id
                            INNER JOIN api_role ON api_role.id = api_role_resource_route.api_role_id
                            WHERE api_role.status = 1
                            AND api_resource_route.status = 1
                            AND api_role_resource_route.status = 1";

                var result = await _connection.QueryAsync<ApiRoleResourceRouteEntity, ApiResourceRouteEntity, ApiRoleEntity, ApiRoleResourceRouteEntity> (
                    sql,
                    (apiRoleResourceRouteEntity, apiRouteResource, apiRole) => {
                        apiRoleResourceRouteEntity.ApiRole = apiRole;
                        apiRoleResourceRouteEntity.ApiResourceRoute = apiRouteResource;
                        return apiRoleResourceRouteEntity;
                    }
                );
                return ResultFlowFactory.Success<IEnumerable<ApiRoleResourceRouteEntity>> (result);
            }
            catch
            {
                throw;
            }
        }

    }
}
