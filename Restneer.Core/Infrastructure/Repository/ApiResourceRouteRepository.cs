using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Core.Infrastructure.Repository
{
    public class ApiResourceRouteRepository : AbstractRepository, 
                                              IApiResourceRouteRepository
    {
        public ApiResourceRouteRepository(IDbConnection connection, IConfiguration configuration)
            : base(connection, configuration)
        {
        }

        public async Task<IEnumerable<ApiResourceRouteEntity>> List(QueryParamValueObject<ApiResourceRouteEntity> model)
        {
            try
            {
                var sql = @"SELECT *
                            FROM api_resource_route 
                            INNER JOIN api_resource ON api_resource_route.api_resource_id = api_resource.id
                            WHERE api_resource_route.status = 1
                            AND api_resource.status = 1";
                return await Connection.QueryAsync<ApiResourceRouteEntity, ApiResourceEntity, ApiResourceRouteEntity>(
                    sql,
                    (apiResourceRoute, apiResource) =>
                    {
                        apiResourceRoute.ApiResource = apiResource;
                        return apiResourceRoute;
                    }
                );
            }
            catch
            {
                throw;
            }
        }
    }
}
