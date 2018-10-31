using StackExchange.Redis;

namespace Restneer.Core.Infrastructure.Connection
{
    public interface IRedisConnectionFactory
    {
        IConnectionMultiplexer Fabricate();
    }
}
