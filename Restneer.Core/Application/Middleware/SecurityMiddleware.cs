using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Restneer.Core.Infrastructure.Service;

namespace Restneer.Core.Application.Middleware
{
    public class SecurityMiddleware : IMiddleware<SecurityMiddleware>
    {
        readonly IRestneerCacheService _restneerCacheService;
        public RequestDelegate Next { get; set; }
        public ILogger<SecurityMiddleware> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public SecurityMiddleware(
            RequestDelegate next,
            IRestneerCacheService restneerCacheService,
            ILogger<SecurityMiddleware> logger,
            IConfiguration configuration
        )
        {
            Next = next;
            _restneerCacheService = restneerCacheService;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var cleanedUrls = ParseUrl(httpContext);
            await ValidateApiResourceRoute(httpContext);
            await Next(httpContext);
            return;
        }

        string[] ParseUrl(HttpContext httpContext)
        {
            try
            {
                string[] cleanedUrls = { };
                int inc = 0;
                foreach (var uriPart in httpContext.Request.Path.Value.Split("/"))
                {
                    if (uriPart != string.Empty)
                    {
                        cleanedUrls[inc] = uriPart.ToLower();
                    }
                    inc++;
                }
                return cleanedUrls;
            }
            catch
            {
                throw;
            }
        }

        async Task ValidateApiResourceRoute(HttpContext httpContext)
        {
            try
            {
                var apiResourceRoutes = _restneerCacheService.GetApiResourceRoute();
                var filteredApiResourceRoutes = apiResourceRoutes.Where(x => x.HttpVerb == httpContext.Request.Method);

                await Next(httpContext);
                return;
            }
            catch
            {
                throw;
            }
        }

        /*
    private validateApiResourceRoute(): any {
        this.requestBundle.restneer.apiResourceRoute = global.restneer.securityPermission.apiResourceRoute
        .filter(resourceRoute => {
            return (
                   this.testResourceRoute(resourceRoute.uriRegex)
                && resourceRoute.httpVerb === this.req.method
            );
        });

        // If there no filteres resource route
        if (this.requestBundle.restneer.apiResourceRoute.length === 0) {
            return Http.respond(this.res, {
                errors: [new Error("Api resource not found")],
                code: Http.code.NOT_FOUND
            });
        }

        if (this.requestBundle.restneer.apiResourceRoute[0]) {
            this.requestBundle.restneer.apiResourceRoute = this.requestBundle.restneer.apiResourceRoute[0];
        }

        if (this.requestBundle.restneer.apiResourceRoute.authenticated) {
            return this.validateJwtToken();
        } else {
            return this.callRoute();
        }
    }

*/
    }
}
