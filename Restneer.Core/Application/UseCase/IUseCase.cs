using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Restneer.Core.Application.UseCase
{
    public interface IUseCase<T>
    {
        ILogger<T> Logger { get; set; }
        IConfiguration Configuration { get; set; }
    }
}
