using PGP.Api.ExceptionHandlers;
using PGP.Infrastructure.Framework.WebApi.ApiMessagesHandlers;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace PGP.Api.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public static class ErrorHandlersConfig
    {
        /// <summary>
        /// Setups the exception handlers.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public static void SetupExceptionHandlers(HttpConfiguration configuration, IApiMessageHandler messageHandler)
        {
            configuration.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger());
            configuration.Services.Add(typeof(IExceptionHandler), new GlobalExceptionHandler(messageHandler));
        }
    }
}