using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Domain.Logic
{
    public interface ILogic<T>
    {
        IResultFlowFactory ResultFlowFactory { get; set; }
        ILogger<T> Logger { get; set; }
        IConfiguration Configuration { get; set; }
    }
}
