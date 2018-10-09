using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Dapper;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Core.Infrastructure.Repository.ApiRole
{
    public class ApiRoleRepository : AbstractRepository, 
                                     IApiRoleRepository
    {

        public ApiRoleRepository(IDbConnection connection)
            : base(connection)
        {
        }

        public Task<long> Create(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiRoleEntity> Read(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApiRoleEntity>> List(QueryParam<ApiRoleEntity> queryParam = null)
        {
            try
            {
                var sql = @"SELECT * 
                               FROM api_role;";
                return await Connection.QueryAsync<ApiRoleEntity>(sql);
            }
            catch
            {
                throw;
            }
        }  
    }
}
