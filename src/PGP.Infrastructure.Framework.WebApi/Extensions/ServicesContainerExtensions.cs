using PGP.Infrastructure.Framework.WebApi.ApiLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

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
