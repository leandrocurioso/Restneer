using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Restneer.Core.Application.Middleware;
using Restneer.Core.Infrastructure.Service;
using System;

namespace Restneer.Web.Api
{
    public class Startup
    {
        Container _container = new Container();
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        void IntegrateSimpleInjector(IServiceCollection services)
        {
            _container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(_container));
            services.AddSingleton<IViewComponentActivator>(
                new SimpleInjectorViewComponentActivator(_container));

            services.EnableSimpleInjectorCrossWiring(_container);
            services.UseSimpleInjectorAspNetRequestScoping(_container);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            IntegrateSimpleInjector(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            InitializeContainer(app);
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseMiddleware<ApiKeyMiddleware>();
            app.UseMiddleware<SecurityMiddleware>();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseMvc();
            app.UseMiddleware<NotFoundMiddleware>();
        }

        void InitializeContainer(IApplicationBuilder app)
        {
            // Add application presentation components:
            _container.RegisterMvcControllers(app);
            // _container.RegisterMvcViewComponents(app);

            _container.RegisterInstance<IConfiguration>(Configuration);

            Core.CompositionRoot.Register(_container);

            // Allow Simple Injector to resolve services from ASP.NET Core.
            _container.AutoCrossWireAspNetComponents(app);

            using (AsyncScopedLifestyle.BeginScope(_container))
            {
                var restneerCacheService = _container.GetInstance<IRestneerCacheService>();
                restneerCacheService.Load();
            }
        }
    }
}
