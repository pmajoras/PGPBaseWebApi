using System;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using PGP.Infrastructure.Framework.WebApi.Extensions;
using PGP.Infrastructure.Framework.WebApi.Helpers;
using PGP.Infrastructure.Framework.WebApi.ApiAuthentication;

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
            var tokenService = ApiServicesHelper.GetRegisteredService<ITokenService>();
            var token = actionContext.GetBearerToken();

            if (!tokenService.ValidateToken(token))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, "Login Inválido");
            }
        }
    }
}