using System.Web.Http;
using System.Web.Http.Controllers;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;

namespace PGP.Infrastructure.Framework.WebApi.Extensions
{
    public static class ServicesContainerExtensions
    {
        /// <summary>
        /// Gets the API trace writer.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IApiTracer GetApiTraceWriter(this ServicesContainer services)
        {
            return services.GetTraceWriter() as IApiTracer;
        }
    }
}