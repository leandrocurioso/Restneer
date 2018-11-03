using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Restneer.Core.Application.Middleware
{
    public interface IMiddleware<T> : IMiddleware
    {
        ILogger<T> Logger { get; set; }
        IConfiguration Configuration { get; set; }
    }
}
