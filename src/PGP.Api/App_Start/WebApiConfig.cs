using System.Web.Http;
using PGP.Api.ApiMessageHandlers;
using PGP.Api.App_Start;
using PGP.Api.Loggers.ImplementedLoggers;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;
using PGP.Infrastructure.Framework.WebApi.Extensions;
using PGP.Infrastructure.Framework.WebApi.Helpers;
using PGP.Domain.DomainHelpers;
using PGP.Infrastructure.Framework.WebApi.ApiAuthentication;

namespace PGP.Api
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Registers the specified configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void Register(HttpConfiguration config)
        {
            var apiMessageHandler = new MessageHandler();
            DomainMessageHelper.MessageHandler = apiMessageHandler;
            ApiServicesHelper.RegisterService<IPGPLogger>(new PGPApiLogger());

            // Web API configuration and services
            ErrorHandlersConfig.SetupExceptionHandlers(config, apiMessageHandler,
                config.Services.GetCurrentApiLogger());
            FormattersConfig.SetupApiFormatters(config);

            // AutoMapper
            AutoMapperConfig.RegisterMapping();

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