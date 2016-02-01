using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperSharp;
using PGP.Domain.Users;
using PGP.Infrastructure.Framework.WebApi.ApiAuthentication;

namespace PGP.Api.Services.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        #region Private Members

        private ITokenService m_tokenService;

        private IUserService m_userService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationService"/> class.
        /// </summary>
        public AuthenticationService(ITokenService tokenService, IUserService userService)
        {
            m_tokenService = tokenService;
            m_userService = userService;
        }

        #endregion

        #region Interface Methods

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public UserCredentials AuthenticateUser(string username, string password)
        {
            var credentials = new UserCredentials();

            var user = m_userService.GetValidUserForLogin(username, password);
            if (user != null)
            {
                credentials.AuthToken = m_tokenService.GenerateToken(user.Id);
                credentials.AuthStatus = CredentialsStatus.Valid;
            }

            return credentials;
        }

        /// <summary>
        /// Gets the user credentials by token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public UserCredentials GetUserCredentialsByToken(string token)
        {
            var credentials = new UserCredentials();

            var authToken = m_tokenService.ValidateToken(token);
            if (authToken != null)
            {
                credentials.AuthStatus = CredentialsStatus.Valid;
                credentials.AuthToken = authToken;
            }

            return credentials;
        }

        /// <summary>
        /// Logoffs the user.
        /// </summary>
        /// <param name="token">The token.</param>
        public bool LogoffUser(string token)
        {
            return m_tokenService.Kill(token);
        }

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        public UserCredentials RegisterUser(User user)
        {
            ExceptionHelper.ThrowIfNull("user", user);
            var credentials = new UserCredentials();

            var savedUser = m_userService.RegisterUser(user.Username, user.Password, user.FullName, user.NickName);  
            m_userService.Commit();

            credentials.AuthToken = m_tokenService.GenerateToken(savedUser.Id);
            credentials.AuthStatus = CredentialsStatus.Valid;

            return credentials;
        }

        #endregion
    }
}
