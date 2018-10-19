using System.Data;
using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Infrastructure.Repository
{
    public abstract class AbstractRepository
    {
        protected readonly IDbConnection Connection;
        protected readonly IConfiguration Configuration;

        public AbstractRepository(IDbConnection connection, IConfiguration configuration)
        {
            Connection = connection;
            Configuration = configuration;
        }
    }
}
