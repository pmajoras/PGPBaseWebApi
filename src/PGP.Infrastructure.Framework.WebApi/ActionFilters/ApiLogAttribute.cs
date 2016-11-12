using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using PGP.Infrastructure.Framework.WebApi.Extensions;
using System;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;

namespace PGP.Infrastructure.Framework.WebApi.ActionFilters
{
    public class ApiLogAttribute : ActionFilterAttribute
    {
        private IPGPLogger m_logger;
        private DateTime m_startedDate;

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            if (actionExecutedContext.Exception == null)
            {
                var executionTime = ((int)(DateTime.Now.Subtract(m_startedDate).TotalMilliseconds)).ToString();
                var httpType = actionExecutedContext.Request.Method.Method;
                var actionName = actionExecutedContext.ActionContext.ActionDescriptor.ActionName;
                var controllerName = actionExecutedContext.ActionContext.ActionDescriptor.ControllerDescriptor.ControllerName;
                var requestPath = actionExecutedContext.Request.RequestUri.LocalPath;

                m_logger.Info(string.Format("{0} - {1} - {2}/{3} - {4} ms", httpType, requestPath, controllerName, actionName, executionTime));
            }
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            m_startedDate = DateTime.Now;
            m_logger = actionContext.RequestContext.Configuration.Services.GetCurrentApiLogger();
        }
    }
}