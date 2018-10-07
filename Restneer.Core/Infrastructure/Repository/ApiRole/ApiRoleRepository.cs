using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Dapper;

namespace Restneer.Core.Infrastructure.Repository.ApiRole
{
    public class ApiRoleRepository : IApiRoleRepository
    {
        readonly IDbConnection _connection;

        public ApiRoleRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<long> Create(ApiRoleEntity entity = null)
        {
            try {
                return await Task.FromResult(0);
            } catch {
                throw;
            }
        }

        public async Task<IEnumerable<ApiRoleEntity>> List(ApiRoleEntity entity = null)
        {
            try {
                var sql = @"SELECT * 
                               FROM api_role;";
                return await _connection.QueryAsync<ApiRoleEntity>(sql);
            } catch {
                throw;
            }
        }
    }
}
