using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Domain.Business
{
    public abstract class AbstractBusiness
    {
        protected readonly IConfiguration Configuration;

        public AbstractBusiness(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
