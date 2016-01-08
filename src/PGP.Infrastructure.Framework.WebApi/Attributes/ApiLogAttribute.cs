using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;

namespace PGP.Infrastructure.Framework.WebApi.Attributes
{
    public class ApiLogAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var trace = actionContext.RequestContext.Configuration.Services.GetTraceWriter();
            trace.Info(actionContext.Request, 
                "Controller : " + 
                actionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + 
                Environment.NewLine + 
                "Action : " + 
                actionContext.ActionDescriptor.ActionName, "JSON", actionContext.ActionArguments);
        }
    }
}
