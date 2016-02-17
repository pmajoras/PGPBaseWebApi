using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using HelperSharp;
using Jose;
using PGP.Infrastructure.Framework.WebApi.ApiAuthentication;

namespace PGP.Api.Services
{
    public class JWTService : ITokenService
    {
        private static double _authTokenExpiryInSeconds = Convert.ToDouble(ConfigurationManager.AppSettings["AuthTokenExpiry"]);

        private static readonly byte[] secretKey = new byte[] { 123, 50, 20, 0, 48, 55, 12, 56, 250, 1, 44, 66, 164, 45, 66, 211, 88, 99, 216, 246, 197, 164, 75, 32, 15, 199, 221, 115, 77, 89, 5, 111 };

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidTokenService"/> class.
        /// </summary>
        public JWTService()
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
            ExceptionHelper.ThrowIfNull("userId", userId);

            DateTime initOn = DateTime.Now;
            DateTime expiresOn = DateTime.Now.AddSeconds(_authTokenExpiryInSeconds);

            var authToken = new AuthenticationToken()
            {
                UserId = userId,
                InitOn = initOn,
                ExpiresOn = expiresOn
            };

            authToken.Token = JWT.Encode(authToken, secretKey, JwsAlgorithm.HS256);

            return authToken;
        }

        /// <summary>
        /// Kills the specified token identifier.
        /// </summary>
        /// <param name="tokenId">The token identifier.</param>
        /// <returns></returns>
        public bool Kill(string token)
        {
            return false;
        }

        /// <summary>
        /// Validates the token.
        /// </summary>
        /// <param name="tokenId">The token identifier.</param>
        /// <returns></returns>
        public AuthenticationToken ValidateToken(string token)
        {
            try
            {
                AuthenticationToken authToken = JWT.Decode<AuthenticationToken>(token, secretKey);

                if (authToken != null &&
                    authToken.UserId != null)
                {
                    if (authToken.ExpiresOn > DateTime.Now)
                    {
                        return GenerateToken(authToken.UserId);
                    }
                }
            }
            catch (Exception)
            {

            }

            return null;
        }

        #endregion
    }
}