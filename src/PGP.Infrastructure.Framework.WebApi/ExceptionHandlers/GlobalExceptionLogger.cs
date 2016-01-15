using System.Web.Http.ExceptionHandling;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;

namespace PGP.Infrastructure.Framework.WebApi.ExceptionHandlers
{
    /// <summary>
    ///
    /// </summary>
    public class GlobalExceptionLogger : ExceptionLogger
    {
        private IPGPLogger m_apiLogger;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionLogger"/> class.
        /// </summary>
        public GlobalExceptionLogger(IPGPLogger apiLogger)
        {
            m_apiLogger = apiLogger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            //context.Request, "Controller : " + context.ExceptionContext.
            //    ActionContext.
            //    ControllerContext.
            //    ControllerDescriptor.ControllerType.FullName +
            //    Environment.NewLine +
            //    "Action : " + context.ExceptionContext.ActionContext.ActionDescriptor.ActionName,
            //    context.Exception

            // TODO
            m_apiLogger.Error("MONTAR MENSAGEM DE ERRO");
        }
    }
}