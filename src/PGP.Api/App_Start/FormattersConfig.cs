using PGP.Infrastructure.Framework.WebApi.Formatters;
using System.Web.Http;

namespace PGP.Api.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public static class FormattersConfig
    {
        /// <summary>
        /// Setups the API formatters.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public static void SetupApiFormatters(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.JsonFormatter);
            formatters.Insert(0, new StandardJsonFormatter());
        }
    }
}