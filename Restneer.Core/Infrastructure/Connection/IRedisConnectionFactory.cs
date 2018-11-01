using StackExchange.Redis;

namespace Restneer.Core.Infrastructure.Connection
{
    public interface IRedisConnectionFactory
    {
        IDatabase Fabricate(int database = 0);
    }
}
