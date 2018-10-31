using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Restneer.Core.Application.Middleware
{
    public interface IMiddleware<T>
    {
        IConfiguration Configuration { get; set; }
        ILogger<T> Logger { get; set; }
        RequestDelegate Next { get; set; }
        Task InvokeAsync(HttpContext httpContext);
    }
}
