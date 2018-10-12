using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Restneer.Core.Model.ValueObject;

namespace Restneer.Core.Application.Middleware
{
    public class NotFoundMiddleware
    {
        readonly RequestDelegate _next;

        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await _next(httpContext);

            httpContext.Response.ContentType = "application/json";

            if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync(new ErrorResponseValueObject()
                {
                    Message = "Not Found"
                }.ToString());
            }
        }
    }
}
