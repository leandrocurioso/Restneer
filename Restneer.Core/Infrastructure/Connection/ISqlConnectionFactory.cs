using System.Data;

namespace Restneer.Core.Infrastructure.Connection
{
    public interface ISqlConnectionFactory
    {
        IDbConnection Fabricate();
    }
}
