using System.Data;

namespace Restneer.Core.Infrastructure.Repository
{
    public class AbstractRepository
    {
        protected readonly IDbConnection Connection;

        public AbstractRepository(IDbConnection connection)
        {
            Connection = connection;
        }
    }
}
