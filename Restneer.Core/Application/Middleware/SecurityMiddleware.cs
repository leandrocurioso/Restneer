using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Model.ValueObject;
using Restneer.Core.Infrastructure.Service;
using Restneer.Core.Infrastructure.Utility;

namespace Restneer.Core.Application.Middleware
{
    public sealed class SecurityMiddleware : IMiddleware<SecurityMiddleware>
    {
        readonly IRestneerCacheService _restneerCacheService;

        readonly IJwtUtility _jwtUtility;
        public ILogger<SecurityMiddleware> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public SecurityMiddleware(
            IJwtUtility jwtUtility,
            IRestneerCacheService restneerCacheService,
            ILogger<SecurityMiddleware> logger,
            IConfiguration configuration
        )
        {
            _jwtUtility = jwtUtility;
            _restneerCacheService = restneerCacheService;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                var urls = UrlTolist(context);
                await ValidateApiResourceRoute(context, next, urls);
                return;
            }
            catch
            {
                throw;
            }
        }

        List<string> UrlTolist(HttpContext context)
        {
            try
            {
                List<string> cleanedUrls = new List<string>();
                foreach (var uriPart in context.Request.Path.Value.ToLower().Split("/"))
                {
                    if (uriPart != string.Empty)
                    {
                        cleanedUrls.Add(uriPart);
                    }
                }
                return cleanedUrls;
            }
            catch
            {
                throw;
            }
        }

        async Task RespondError(HttpContext context, string message, HttpStatusCode httpStatusCode)
        {
            try
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)httpStatusCode;
                var errorObj = new
                {
                    errors = new object[] {
                            new ErrorResponseValueObject() {
                                message = message
                            }
                        }
                };
                await context.Response.WriteAsync(JsonConvert.SerializeObject(errorObj));
                return;
            }
            catch
            {
                throw;
            }
        }

        bool ValidateUriPattern(List<string> requestUrls, string uriPattern)
        {
            try
            {
                var urls = uriPattern.ToLower().Split("/").Skip(1).ToArray();
                var inc = 2;
                var validList = new List<bool>();
                foreach (string url in urls)
                {
                    var currentUrl = requestUrls.ElementAt(inc);
                    if (url != string.Empty && url.First().ToString() == "{" && url.Last().ToString() == "}")
                    {
                        var clearedUrl = url.Substring(1, url.Length - 2);
                        var urlParams = clearedUrl.Split(":");
                        var paramType = urlParams[1];
                        if (paramType == "long" || paramType == "int")
                        {
                            if (long.TryParse(currentUrl, out long value))
                            {
                                validList.Add(true);
                            }
                            else
                            {
                                validList.Add(false);
                            }
                        }

                        if (paramType == "string")
                        {
                            if (url == currentUrl)
                            {
                                validList.Add(true);
                            }
                            else
                            {
                                validList.Add(false);
                            }
                        }
                    }
                    else
                    {
                        if (url == currentUrl)
                        {
                            validList.Add(true);
                        }
                        else
                        {
                            validList.Add(false);
                        }
                    }
                    inc++;
                }
                return validList.All(x => x == true);
            }
            catch
            {
                throw;
            }
        }

        void LogRequest(HttpContext context, ApiResourceRouteEntity apiResourceRoute, ApiRoleResourceRouteEntity apiRoleResourceRoute = null,JwtSecurityToken jwtSecurityToken = null)
        {
            try
            {
                var logObj = new
                {
                    // body = await context.ReadAsStringAsync(),
                    cookie = context.Request.Cookies,
                    query = context.Request.QueryString.Value,
                    headers = context.Request.Headers,
                    apiResourceRoute,
                    apiRoleResourceRoute,
                    jwtSecurityToken,
                    timestamp = DateTime.UtcNow
                };
                Logger.LogInformation(JsonConvert.SerializeObject(logObj));
            }
            catch
            {
                throw;
            }
        }

        async Task ValidateApiRoleResourceRole(HttpContext context, ApiResourceRouteEntity apiResourceRouteEntity, JwtSecurityToken jwtSecurityToken = null)
        {
            try
            {
                var apiRoleResourceRoutes = _restneerCacheService.GetApRoleResourceRoute();
                var apiRoleResourceRoute = apiRoleResourceRoutes.Where(
                    x => x.ApiRole.Id == Convert.ToInt64(jwtSecurityToken.Issuer)
                    && x.ApiResourceRoute.Id == apiResourceRouteEntity.Id
                ).ToList();

                if (!apiRoleResourceRoute.Any())
                {
                    await RespondError(context, "You do not have the permission to call this resource.", HttpStatusCode.Forbidden);
                }

                if (apiResourceRouteEntity.IsLogged)
                {
                    LogRequest(context, apiResourceRouteEntity, apiRoleResourceRoute.ElementAt(0), jwtSecurityToken);
                }
                return;
            }
            catch
            {
                throw;
            }
        }

        async Task ValidateApiResourceRoute(HttpContext context, RequestDelegate next, List<string> urls)
        {
            try
            {
                var apiResourceRoutes = _restneerCacheService.GetApiResourceRoute();
                var filteredApiResourceRoutes = apiResourceRoutes.Where(
                       x => x.HttpVerb == context.Request.Method
                    && x.Version == urls.ElementAt(0)
                    && x.ApiResource.Uri == $"/{urls.ElementAt(1)}"
                    && ValidateUriPattern(urls, x.UriPattern)
                ).ToList();

                if (!filteredApiResourceRoutes.Any())
                {
                    await RespondError(context, "Not Found", HttpStatusCode.NotFound);
                    return;
                }

                var apiResourceRoute = filteredApiResourceRoutes.ElementAt(0);
                if (apiResourceRoute.IsAuthenticated)
                {
                    await ValidateAuthorization(context, next, apiResourceRoute);
                    return;
                }
                if (apiResourceRoute.IsLogged)
                {
                    LogRequest(context, apiResourceRoute);
                }
                await next(context);
                return;
            }
            catch
            {
                throw;
            }
        }

        async Task ValidateAuthorization(HttpContext context, RequestDelegate next,  ApiResourceRouteEntity apiResourceRoute)
        {
            try
            {
                var authorizationHeader = (string)context.Request.Headers["Authorization"];
                if (authorizationHeader == null)
                {
                    await RespondError(context, "Invalid authorization token", HttpStatusCode.Forbidden);
                    return;
                }

                var parts = authorizationHeader.Split(" ");
                var audience = $"{context.Request.Scheme}://{context.Request.Host.Value}";
                if (parts.Length != 2)
                {
                    await RespondError(context, "Invalid authorization token", HttpStatusCode.Forbidden);
                    return;
                }
                var jwtToken = _jwtUtility.DecodeJwt(parts[1]);
                if (jwtToken == null) {
                    await RespondError(context, "Invalid authorization token", HttpStatusCode.Forbidden);
                    return;
                }
                var isValidToken = _jwtUtility.ValidateJwt(parts[1], Configuration.GetSection("Server:Jwt:SecretKey").Value, audience, jwtToken.Issuer);
                if (parts[0] != "Bearer" || !isValidToken)
                {
                    await RespondError(context, "Invalid authorization token", HttpStatusCode.Forbidden);
                }
                else
                {
                    await ValidateApiRoleResourceRole(context, apiResourceRoute, jwtToken);
                    await next(context);
                }
                return;
            }
            catch
            {
                throw;
            }
        }
    }
}
