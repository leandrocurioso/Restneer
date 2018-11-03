using System.Data;
using Dapper;
using Restneer.Core.Domain.Model.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Infrastructure.Repository
{
    public class ApiUserRepository : IApiUserRepository
    {
        readonly IDbConnection _connection;
        public ILogger<IApiUserRepository> Logger { get; set; }
        public IResultFlowFactory ResultFlowFactory { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiUserRepository(
            IDbConnection connection, 
            IResultFlowFactory resultFlowFactory,
            ILogger<IApiUserRepository> logger,
            IConfiguration configuration
        )
        {
            _connection = connection;
            ResultFlowFactory = resultFlowFactory;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task<ResultFlow<ApiUserEntity>> Authenticate(string email, string encryptedPassword)
        {
            try
            {
                var sql = @"SELECT api_user.id,
                                   api_user.email,
                                   api_role.id
                            FROM api_user 
                            INNER JOIN api_role ON api_role.id = api_user.api_role_id
                            WHERE api_user.email = LOWER(@Email)
                            AND api_user.password = @Password
                            AND api_user.status = 1
                            LIMIT 1";
                var result = await _connection.QueryAsync<ApiUserEntity, ApiRoleEntity, ApiUserEntity>(
                    sql,
                    map: (apiUser, apiRole) => {
                        apiUser.ApiRole = apiRole;
                        return apiUser;
                    },
                    param: new
                    {
                        Email = email,
                        Password = encryptedPassword
                    }
                );
                return ResultFlowFactory.Success<ApiUserEntity>(result.FirstOrDefault());
            }
            catch
            {
                throw;
            }
        }

        public async Task<ResultFlow<ApiUserEntity>> Read(ApiUserEntity model)
        {
            try {
                var sql = @"SELECT * 
                            FROM api_user
                            WHERE id = @Id";
                var result = await _connection.QueryAsync<ApiUserEntity>(
                    sql,
                    param: new
                    {
                        Id = model.Id
                    }
                );
                return ResultFlowFactory.Success<ApiUserEntity>(result.FirstOrDefault());
            } catch {
                throw;
            }
        }
    }
}
