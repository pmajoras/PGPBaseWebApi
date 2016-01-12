using PGP.Api.ApiMessageHandlers;
using PGP.Api.App_Start;
using PGP.Api.Loggers;
using PGP.Infrastructure.Framework.WebApi.Extensions;
using PGP.Infrastructure.Framework.WebApi.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace PGP.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Services.Replace(typeof(ITraceWriter), new NLogger());

            // Web API configuration and services
            ErrorHandlersConfig.SetupExceptionHandlers(config, new MessageHandler(), config.Services.GetApiTraceWriter());
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
