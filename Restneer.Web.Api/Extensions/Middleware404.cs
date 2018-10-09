using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Web.Api.Extensions
{
    public class Middleware404
    {
        readonly RequestDelegate _next;

        public Middleware404(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);

            httpContext.Response.ContentType = "application/json";

            if (httpContext.Response.StatusCode == 404)
            {
                await httpContext.Response.WriteAsync(new ErrorResponse()
                {
                    StatusCode = httpContext.Response.StatusCode,
                    Message = "Not Found"
                }.ToString());
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class Middleware404Extensions
    {
        public static IApplicationBuilder UseMiddleware404(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware404>();
        }
    }
}
