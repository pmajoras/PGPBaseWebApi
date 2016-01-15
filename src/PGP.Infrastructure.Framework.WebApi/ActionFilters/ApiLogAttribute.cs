using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;
using PGP.Infrastructure.Framework.WebApi.Extensions;

namespace PGP.Infrastructure.Framework.WebApi.ActionFilters
{
    public class ApiLogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var trace = actionContext.RequestContext.Configuration.Services.GetApiTraceWriter();

            trace.Warn(actionContext.Request,
                "Controller: " +
                actionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName +
                Environment.NewLine +
                "Action : " +
                actionContext.ActionDescriptor.ActionName, "JSON", actionContext.ActionArguments);
        }
    }
}