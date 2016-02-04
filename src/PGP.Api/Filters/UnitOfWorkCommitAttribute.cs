using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using PGP.Api.HttpControllerActivators;
using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class UnitOfWorkCommitAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Called when [action executed].
        /// </summary>
        /// <param name="actionExecutedContext">The action executed context.</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var activator = GlobalConfiguration.Configuration.Services.GetHttpControllerActivator() as NinjectKernelActivator;
            if (activator != null)
            {
                var unitOfWork = activator.Kernel.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
                if (unitOfWork != null)
                {
                    unitOfWork.Commit();
                }
            }
        }
    }
}