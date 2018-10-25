using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Restneer.Core.Domain.Logic
{
    public interface ILogic<T>
    {
        ILogger<T> Logger { get; set; }
        IConfiguration Configuration { get; set; }
    }
}
