using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Prospa.BusinessMatcher.Service;
using Prospa.BusinessMatcher.Service.Data;
using Prospa.BusinessMatcher.Service.Factories;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace Prospa.BusinessMatcher.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            Container container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.AllowOverridingRegistrations = true;
            container.RegisterWebApiControllers(config);
            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
            RegisterServices(container);

            config.EnsureInitialized();
        }

        private static void RegisterServices(Container container) 
        {
            container.Register<IBusinessMatcherFactory>(
            () => { return SingletonBusinessMatcherFactory.GetOrCreateInstance(); }, 
            Lifestyle.Singleton);

            container.Register<IBusinessDataRepository, BusinessDataRepository>(Lifestyle.Singleton);

            container.Register<IBusinessRecordsService, BusinessRecordsService>(Lifestyle.Transient);

            container.Verify();
        }
    }
}
