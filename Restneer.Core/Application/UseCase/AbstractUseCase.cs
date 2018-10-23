using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Application.UseCase
{
    public abstract class AbstractUseCase
    {
        protected readonly IConfiguration Configuration;

        protected AbstractUseCase(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}
