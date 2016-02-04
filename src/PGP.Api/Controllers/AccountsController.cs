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
using PGP.Infrastructure.Framework.Messages;
using PGP.Api.Messages;
using PGP.Api.App_Start;
using PGP.Domain.Users;

namespace PGP.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [RoutePrefix("api/accounts")]
    public class AccountsController : ApiControllerBase
    {
        #region Private Members

        IAuthenticationService m_authenticationService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountsController"/> class.
        /// </summary>
        public AccountsController(IAuthenticationService authenticationService)
        {
            m_authenticationService = authenticationService;
        }

        #endregion

        #region Actions

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Login")]
        public ApiResult<ApiResponse> Login([FromBody] LoginViewModel loginRequest)
        {
            if (loginRequest == null)
            {
                var error = m_messageHandler.GetErrorFromEnum(ApiMessageCode.RequiredParameter);
                error.FieldName = "loginRequest";
                return ApiBadRequestResult(error);
            }

            var credentials = m_authenticationService.AuthenticateUser(loginRequest.Username, loginRequest.Password);
            return ApiOkResult(credentials);
        }

        /// <summary>
        /// Saves the user.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public ApiResult<ApiResponse> Register([FromBody] UserViewModel user)
        {
            if (user == null)
            {
                var error = m_messageHandler.GetErrorFromEnum(ApiMessageCode.RequiredParameter);
                error.FieldName = "user";
                return ApiBadRequestResult(error);
            }

            var userToRegister = AutoMapperConfig.MapperConfig.Map<User>(user);
            var registeredUser = m_authenticationService.RegisterUser(userToRegister);

            Commit();

            user = AutoMapperConfig.MapperConfig.Map<UserViewModel>(registeredUser);
            return ApiOkResult(user);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("Logoff")]
        [BearerAuthenticationFilter]
        public ApiResult<ApiResponse> Logoff()
        {
            m_authenticationService.LogoffUser(CurrentAuthToken.Token);
            return ApiOkResult();
        }

        #endregion
    }
}