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
        public bool Kill(string tokenId)
        {
            return m_authenticatedTokens.Remove(tokenId);
        }

        /// <summary>
        /// Validates the token.
        /// </summary>
        /// <param name="tokenId">The token identifier.</param>
        /// <returns></returns>
        public AuthenticationToken ValidateToken(string tokenId)
        {
            AuthenticationToken token = null;
            m_authenticatedTokens.TryGetValue(tokenId, out token);

            if (token != null)
            {
                if (token.ExpiresOn > DateTime.Now)
                {
                    token.ExpiresOn = token.ExpiresOn.AddSeconds(_authTokenExpiryInSeconds);
                    return token;
                }
                else
                {
                    Kill(tokenId);
                }
            }

            return null;
        }

        #endregion
    }
}