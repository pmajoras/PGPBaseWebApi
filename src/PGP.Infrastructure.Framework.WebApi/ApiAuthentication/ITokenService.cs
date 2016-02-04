using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Framework.WebApi.ApiAuthentication
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Validates the token.
        /// </summary>
        /// <param name="tokenId">The token identifier.</param>
        /// <returns></returns>
        AuthenticationToken ValidateToken(string token);

        /// <summary>
        /// Kills the specified token identifier.
        /// </summary>
        /// <param name="tokenId">The token identifier.</param>
        /// <returns></returns>
        bool Kill(string token);

        /// <summary>
        /// Generates the token.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        AuthenticationToken GenerateToken(object userId);
    }
}
