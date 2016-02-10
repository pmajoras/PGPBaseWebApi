using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace PGP.Infrastructure.Framework.WebApi.Extensions
{
    public static class HttpActionContextExtensions
    {
        /// <summary>
        /// Gets the bearer token.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        /// <returns></returns>
        public static string GetBearerToken(this HttpActionContext actionContext)
        {
            string headerKey = "Authorization";
            string authToken = string.Empty;

            if (actionContext.Request.Headers.Any(x => x.Key == headerKey))
            {
                authToken = actionContext.Request.Headers.First(x => x.Key == headerKey).Value.First();
                if (!string.IsNullOrEmpty(authToken) && authToken.Contains("Bearer "))
                {
                    authToken = authToken.Split(new string[] { "Bearer " }, StringSplitOptions.RemoveEmptyEntries)
                        .Last();
                }
            }

            return authToken;
        }
    }
}
