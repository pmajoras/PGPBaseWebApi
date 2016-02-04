using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace PGP.Infrastructure.Framework.WebApi.ApiAuthentication
{
    /// <summary>
    /// 
    /// </summary>
    public class GuidTokenService : ITokenService
    {
        private static Dictionary<string, AuthenticationToken> m_authenticatedTokens = new Dictionary<string, AuthenticationToken>();

        private static double _authTokenExpiryInSeconds = Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]);

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidTokenService"/> class.
        /// </summary>
        public GuidTokenService()
        {

        }

        #endregion

        #region Interface Methods

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public AuthenticationToken GenerateToken(object userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            string token = Guid.NewGuid().ToString();
            DateTime issuesOn = DateTime.Now;
            DateTime expiresOn = DateTime.Now.AddSeconds(_authTokenExpiryInSeconds);

            var authToken = new AuthenticationToken()
            {
                UserId = userId,
                Token = token,
                InitOn = issuesOn,
                ExpiresOn = expiresOn
            };

            m_authenticatedTokens.Add(token, authToken);

            return authToken;
        }

        /// <summary>
        /// Kills the specified token identifier.
        /// </summary>
        /// <param name="tokenId">The token identifier.</param>
        /// <returns></returns>
        public bool Kill(string token)
        {
            return m_authenticatedTokens.Remove(token);
        }

        /// <summary>
        /// Validates the token.
        /// </summary>
        /// <param name="tokenId">The token identifier.</param>
        /// <returns></returns>
        public AuthenticationToken ValidateToken(string token)
        {
            AuthenticationToken authToken = null;
            m_authenticatedTokens.TryGetValue(token, out authToken);

            if (authToken != null)
            {
                if (authToken.ExpiresOn > DateTime.Now)
                {
                    authToken.ExpiresOn = authToken.ExpiresOn.AddSeconds(_authTokenExpiryInSeconds);
                    return authToken;
                }
                else
                {
                    Kill(token);
                }
            }

            return null;
        }

        #endregion
    }
}