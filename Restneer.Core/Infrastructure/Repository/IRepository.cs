using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        ILogger<T> Logger { get; set; }
        IConfiguration Configuration { get; set; }
        IResultFlowFactory ResultFlowFactory { get; set; }
    }
}
