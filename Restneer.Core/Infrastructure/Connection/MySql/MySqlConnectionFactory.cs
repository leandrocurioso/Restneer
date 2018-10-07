using System;
using System.Data;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Infrastructure.Connection.MySql
{
    public class MySqlConnectionFactory : ISqlConnectionFactory
    {
        public IConfiguration Configuration { get; }

        public MySqlConnectionFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection Fabricate()
        {
            try {
                var connectionString = Configuration.GetConnectionString("Default");
                var connection = new MySqlConnection(connectionString);
                return connection;
            } catch {
                throw;
            }
        }
    }
}
