using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGP.Infrastructure.Framework.WebApi.ApiAuthentication;

namespace PGP.Api.Services.Accounts
{
    /// <summary>
    /// 
    /// </summary>
    public class UserCredentials
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserCredentials"/> class.
        /// </summary>
        public UserCredentials()
        {
            AuthStatus = CredentialsStatus.Invalid;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the authentication status.
        /// </summary>
        /// <value>
        /// The authentication status.
        /// </value>
        public CredentialsStatus AuthStatus { get; set; }

        /// <summary>
        /// Gets or sets the authentication token.
        /// </summary>
        /// <value>
        /// The authentication token.
        /// </value>
        public AuthenticationToken AuthToken { get; set; }

        #endregion Properties
    }

    /// <summary>
    /// User Credentials status
    /// </summary>
    public enum CredentialsStatus
    {
        /// <summary>
        /// Valid Login.
        /// </summary>
        Valid = 1,

        /// <summary>
        /// Invalid Login.
        /// </summary>
        Invalid = 2,

        /// <summary>
        /// Password has expired.
        /// </summary>
        PasswordExpired = 3,

        /// <summary>
        /// User is Blocked.
        /// </summary>
        UserBlocked = 4
    }
}
