using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Dapper;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Core.Infrastructure.Repository.ApiRoleResourceRoute
{
    public class ApiRoleResourceRouteRepository : AbstractRepository,
                                                  IApiRoleResourceRouteRepository
    {

        public ApiRoleResourceRouteRepository(IDbConnection connection)
            : base(connection)
        {
        }

        public async Task<IEnumerable<ApiRoleResourceRouteEntity>> List(QueryParamValueObject<ApiRoleResourceRouteEntity> model)
        {
            try
            {
                var sql = @"SELECT * 
                               FROM api_role_resource_route;";
                return await Connection.QueryAsync<ApiRoleResourceRouteEntity>(sql);
            }
            catch
            {
                throw;
            }
        }

    }
}
