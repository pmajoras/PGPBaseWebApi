using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using PGP.Infrastructure.Framework.WebApi.Extensions;
using PGP.Infrastructure.Framework.WebApi.Helpers;
using PGP.Infrastructure.Framework.WebApi.ApiAuthentication;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Api.Services.Accounts;
using System.Web.Http;
using PGP.Api.HttpControllerActivators;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using PGP.Api.Controllers;

namespace PGP.Api.Filters
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class BearerAuthenticationFilterAttribute : AuthorizationFilterAttribute
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BearerAuthenticationFilterAttribute"/> class.
        /// </summary>
        public BearerAuthenticationFilterAttribute()
            : base()
        {

        }

        #endregion

        /// <summary>
        /// Calls when a process requests authorization.
        /// </summary>
        /// <param name="actionContext">The action context, which encapsulates information for using <see cref="T:System.Web.Http.Filters.AuthorizationFilterAttribute" />.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var activator = GlobalConfiguration.Configuration.Services.GetHttpControllerActivator()
                as NinjectKernelActivator;

            var authService = activator.Kernel.GetService(typeof(IAuthenticationService)) as IAuthenticationService;

            var token = actionContext.GetBearerToken();

            var credentials = authService.GetUserCredentialsByToken(token);
            if (credentials.AuthStatus == CredentialsStatus.Invalid)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized,
                    new ApiResponse(credentials));
            }

            var controller = actionContext.ControllerContext.Controller as ApiControllerBase;
            if (controller != null)
            {
                controller.CurrentAuthToken = credentials.AuthToken;
            }
        }
    }
}