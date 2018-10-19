using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Infrastructure.Connection.MySql
{
    public class MySqlConnectionFactory : ISqlConnectionFactory
    {
        public IConfiguration Configuration { get; }

        static MySqlConnectionFactory(){
           Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;  
        }

        public MySqlConnectionFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection Fabricate()
        {
            try {
                var connectionString = Configuration.GetConnectionString("Default");
                var connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            } catch {
                throw;
            }
        }
    }
}
