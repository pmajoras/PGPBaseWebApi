using PGP.Infrastructure.Framework.WebApi.ApiLogs;
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
        /// <param name="messageHandler">The message handler.</param>
        /// <param name="apiTracer">The API tracer.</param>
        public static void SetupExceptionHandlers(
            HttpConfiguration configuration, 
            IApiMessageHandler messageHandler, 
            IApiTracer apiTracer)
        {
            configuration.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger(apiTracer));
            configuration.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler(messageHandler));
        }
    }
}