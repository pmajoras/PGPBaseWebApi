using System.Web.Http.ExceptionHandling;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;
using System.Web.Http;

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
            var actionContext = ((ApiController)context.ExceptionContext.ControllerContext.Controller).ActionContext;
            var request = context.ExceptionContext.Request;

            var httpType = request.Method.Method;
            var actionName = actionContext.ActionDescriptor.ActionName;
            var controllerName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            var requestPath = request.RequestUri.LocalPath;
            var exceptionName = context.Exception.GetType().FullName;
            string source = "";
            if (context.Exception.TargetSite != null)
            {
                source = context.Exception.TargetSite.ToString();
            }

            m_apiLogger.Error(string.Format("{0} - {1} - {2}/{3} - {4} {5}", httpType, requestPath, controllerName, actionName, exceptionName, source));
        }
    }
}