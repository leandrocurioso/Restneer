using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Restneer.Core.Application.UseCase
{
    public abstract class AbstractUseCase
    {
        protected ILogger Logger;
        protected readonly IConfiguration Configuration;

        protected AbstractUseCase(ILogger logger, IConfiguration configuration)
        {
            Logger = logger;
            Configuration = configuration;
        }
    }
}
