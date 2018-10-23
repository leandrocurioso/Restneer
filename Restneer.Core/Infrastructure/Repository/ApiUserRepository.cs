using System.Data;
using Dapper;
using Restneer.Core.Domain.Model.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Infrastructure.Repository
{
    public class ApiUserRepository : AbstractRepository
    {
        public ApiUserRepository(IDbConnection connection, IConfiguration configuration)
             : base(connection, configuration)
        {
        }

        public virtual async Task<ApiUserEntity> Authenticate(string email, string encryptedPassword)
        {
            try 
            {
                var sql = @"SELECT api_user.id,
                                   api_user.email,
                                   api_role.id
                            FROM api_user 
                            INNER JOIN api_role ON api_role.id = api_user.api_role_id
                            WHERE api_user.email = @Email
                            AND api_user.password = @Password
                            AND api_user.status = 1
                            LIMIT 1";
                var result = await Connection.QueryAsync<ApiUserEntity, ApiRoleEntity, ApiUserEntity>(
                    sql,
                    map: (apiUser, apiRole) => {
                        apiUser.ApiRole = apiRole;
                        return apiUser;
                    },
                    param: new
                    {
                        Email = email.ToLower(),
                        Password = encryptedPassword
                    }
                );
                return result.FirstOrDefault();
            } catch {
                throw;
            }

        }
    }
}
