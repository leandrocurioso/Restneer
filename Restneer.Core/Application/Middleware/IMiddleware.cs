using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Application.Middleware
{
    public interface IMiddleware
    {
        IConfiguration Configuration { get; set; }
        RequestDelegate Next { get; set; }
        Task InvokeAsync(HttpContext httpContext);
    }
}
