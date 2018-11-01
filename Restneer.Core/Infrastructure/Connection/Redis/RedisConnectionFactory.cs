using System;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Restneer.Core.Infrastructure.Connection.Redis
{
    public class RedisConnectionFactory : IRedisConnectionFactory
    {
        readonly IConfiguration _configuration;

        public RedisConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDatabase Fabricate(int database = 0)
        {
            try {
                var connectionString = _configuration.GetConnectionString("RedisDefault");
                var redisConnection = ConnectionMultiplexer.Connect(connectionString);
                return redisConnection.GetDatabase(database);
            }
            catch {
                throw;
            }
        }
    }
}
