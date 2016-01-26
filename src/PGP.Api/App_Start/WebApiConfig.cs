using System.Web.Http;
using PGP.Api.ApiMessageHandlers;
using PGP.Api.App_Start;
using PGP.Api.Loggers.ImplementedLoggers;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;
using PGP.Infrastructure.Framework.WebApi.Extensions;
using PGP.Infrastructure.Framework.WebApi.Helpers;

namespace PGP.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ApiServicesHelper.RegisterService<IPGPLogger>(new PGPApiLogger());
            // Web API configuration and services
            ErrorHandlersConfig.SetupExceptionHandlers(config, new MessageHandler(),
                config.Services.GetCurrentApiLogger());
            FormattersConfig.SetupApiFormatters(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}