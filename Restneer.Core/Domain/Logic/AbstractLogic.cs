using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Domain.Logic
{
    public abstract class AbstractLogic
    {
        protected readonly IConfiguration Configuration;

        protected AbstractLogic(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
