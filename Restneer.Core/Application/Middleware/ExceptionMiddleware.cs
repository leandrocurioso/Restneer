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
        public ILogger<ExceptionMiddleware> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ExceptionMiddleware(
            ILogger<ExceptionMiddleware> logger,
            IConfiguration configuration
        )
        {
            Logger = logger;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
                return;
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
                return;
            }
        }

        public  async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            Logger.LogError(JsonConvert.SerializeObject(new {
                Message = exception.Message,
                StackTrace = exception.StackTrace
            }));
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            var errorObj = new
            {
                errors = new object[] {
                    new ErrorResponseValueObject() {
                        message = exception.Message
                    }
                }
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorObj));
            return;
        }
    }
}
