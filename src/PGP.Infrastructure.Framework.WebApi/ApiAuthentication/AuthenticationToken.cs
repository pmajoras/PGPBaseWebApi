using System;

namespace PGP.Infrastructure.Framework.WebApi.ApiAuthentication
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationToken
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationToken"/> class.
        /// </summary>
        public AuthenticationToken()
        {

        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the initialize on.
        /// </summary>
        /// <value>
        /// The initialize on.
        /// </value>
        public DateTime InitOn { get; set; }

        /// <summary>
        /// Gets or sets the expires on.
        /// </summary>
        /// <value>
        /// The expires on.
        /// </value>
        public DateTime ExpiresOn { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public object UserId { get; set; }

        #endregion

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "UserId - " + UserId.ToString() + " - " + Token;
        }
    }
}