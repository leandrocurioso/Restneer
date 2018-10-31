using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Restneer.Core.Infrastructure.Model.ValueObject;

namespace Restneer.Core.Application.Middleware
{
    public class ExceptionMiddleware  : IMiddleware<ExceptionMiddleware>
    {
        public RequestDelegate Next { get; set; }
        public ILogger<ExceptionMiddleware> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ExceptionMiddleware(
            RequestDelegate next,
            ILogger<ExceptionMiddleware> logger,
            IConfiguration configuration
        )
        {
            Next = next;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await Next(httpContext);
                return;
            }
            catch (Exception ex)
            {
                 await HandleExceptionAsync(httpContext, ex);
                return;
            }
        }

        public  async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            Logger.LogError(JsonConvert.SerializeObject(new {
                Message = exception.Message,
                StackTrace = exception.StackTrace
            }));
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            var errorObj = new
            {
                errors = new object[] {
                    new ErrorResponseValueObject() {
                        message = exception.Message
                    }
                }
            };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorObj));
            return;
        }
    }
}
