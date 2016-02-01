using System.Web.Http;
using PGP.Api.Models.Accounts;
using PGP.Infrastructure.Framework.WebApi.ActionFilters;
using PGP.Infrastructure.Framework.WebApi.Controllers;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using PGP.Infrastructure.Repositories.EF;
using System.Linq;
using System;
using PGP.Api.Filters;
using PGP.Api.Services.Accounts;

namespace PGP.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/accounts")]
    public class AccountsController : PGPApiController
    {
        #region Private Members

        IAuthenticationService m_authenticationService;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsController"/> class.
        /// </summary>
        public AccountsController(IAuthenticationService authenticationService)
        {
            m_authenticationService = authenticationService;
        }

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public ApiResult<ApiResponse> Login([FromBody] LoginViewModel loginRequest)
        {
            var credentials = m_authenticationService.AuthenticateUser(loginRequest.Username, loginRequest.Password);
            return ApiOkResult(credentials);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Logoff")]
        [BearerAuthenticationFilter()]
        public ApiResult<ApiResponse> Logoff(UserViewModel entity)
        {
            return ApiOkResult();
        }
    }
}