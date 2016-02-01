using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGP.Domain.Users;

namespace PGP.Api.Services.Accounts
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        UserCredentials AuthenticateUser(string username, string password);

        /// <summary>
        /// Logoffs the user.
        /// </summary>
        /// <param name="token">The token.</param>
        bool LogoffUser(string token);

        /// <summary>
        /// Gets the user credentials by token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        UserCredentials GetUserCredentialsByToken(string token);

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        UserCredentials RegisterUser(User user);
    }
}
