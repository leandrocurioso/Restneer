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

        public IConnectionMultiplexer Fabricate()
        {
            try {
                var connectionString = _configuration.GetConnectionString("RedisDefault");
                return ConnectionMultiplexer.Connect(connectionString);
            }
            catch {
                throw;
            }
        }
    }
}
