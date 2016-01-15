using System.Web.Http.Controllers;
using System.Web.Http.Filters;
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
            //actionContext.Request,
            //    "Controller: " +
            //    actionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName +
            //    Environment.NewLine +
            //    "Action : " +
            //    actionContext.ActionDescriptor.ActionName, "JSON", actionContext.ActionArguments

            var logger = actionContext.RequestContext.Configuration.Services.GetCurrentApiLogger();
            // TODO
            logger.Info("MONTAR MENSAGEM");
        }
    }
}