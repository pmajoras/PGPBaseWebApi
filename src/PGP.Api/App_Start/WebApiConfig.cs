using PGP.Api.App_Start;
using PGP.Infrastructure.Framework.WebApi.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace PGP.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            ErrorHandlersConfig.SetupExceptionHandlers(config, null);
            FormattersConfig.SetupApiFormatters(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
