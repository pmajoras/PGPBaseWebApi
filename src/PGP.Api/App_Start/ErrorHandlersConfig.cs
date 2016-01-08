using PGP.Infrastructure.Framework.WebApi.ApiMessagesHandlers;
using PGP.Infrastructure.Framework.WebApi.ExceptionHandlers;
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
            configuration.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger(null));
            configuration.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler(null));
        }
    }
}