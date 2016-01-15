using System;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;

namespace PGP.Infrastructure.Framework.WebApi.ExceptionHandlers
{
    /// <summary>
    ///
    /// </summary>
    public class GlobalExceptionLogger : ExceptionLogger
    {
        private IApiTracer m_apiTracer;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionLogger"/> class.
        /// </summary>
        public GlobalExceptionLogger(IApiTracer apiTracer)
        {
            m_apiTracer = apiTracer;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            m_apiTracer.Error(context.Request, "Controller : " + context.ExceptionContext.
                ActionContext.
                ControllerContext.
                ControllerDescriptor.ControllerType.FullName +
                Environment.NewLine +
                "Action : " + context.ExceptionContext.ActionContext.ActionDescriptor.ActionName,
                context.Exception);

            base.Log(context);
        }
    }
}