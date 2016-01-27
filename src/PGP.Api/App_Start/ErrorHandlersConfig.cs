using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;
using PGP.Infrastructure.Framework.WebApi.ExceptionHandlers;
using PGP.Infrastructure.Framework.Messages.MessageHandlers;

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
        /// <param name="pgpLogger">The PGP logger.</param>
        public static void SetupExceptionHandlers(
            HttpConfiguration configuration,
            IMessageHandler messageHandler,
            IPGPLogger pgpLogger)
        {
            configuration.Services.Add(typeof(IExceptionLogger), new GlobalExceptionLogger(pgpLogger));
            configuration.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler(messageHandler));
        }
    }
}