using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Dapper;
using Restneer.Core.Domain.Model.ValueObject;
using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Infrastructure.Repository
{
    public class ApiRoleResourceRouteRepository : AbstractRepository, 
                                                  IApiRoleResourceRouteRepository
    {

        public ApiRoleResourceRouteRepository(IDbConnection connection, IConfiguration configuration)
            : base(connection, configuration)
        {
        }

        public async Task<IEnumerable<ApiRoleResourceRouteEntity>> List(QueryParamValueObject<ApiRoleResourceRouteEntity> model)
        {
            try
            {
                var sql = @"SELECT api_resource_route.id AS api_resource_route_id, 
                                   api_resource_route.api_resource_id AS api_resource_route_api_resource_id, 
                                   api_resource_route.`name` AS api_resource_route_name, 
                                   api_resource_route.uri_pattern, 
                                   api_resource_route.is_logged, 
                                   api_resource_route.is_authenticated, 
                                   api_resource_route.version, 
                                   api_resource_route.http_verb, 
                                   api_resource_route.`status` AS api_resource_route_status, 
                                   api_resource.uri, 
                                   api_resource.`name` AS api_resource_name, 
                                   api_resource.`status` AS api_resource_status
                            FROM api_resource_route INNER JOIN api_resource ON api_resource_route.api_resource_id = api_resource.id";
                return await Connection.QueryAsync<ApiRoleResourceRouteEntity>(sql);
            }
            catch
            {
                throw;
            }
        }

    }
}
