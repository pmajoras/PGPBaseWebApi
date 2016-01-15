using System;
using System.Web.Http.Controllers;
using PGP.Infrastructure.Framework.WebApi.ApiLogs;
using PGP.Infrastructure.Framework.WebApi.Helpers;

namespace PGP.Infrastructure.Framework.WebApi.Extensions
{
    public static class ServicesContainerExtensions
    {
        /// <summary>
        /// Gets the current API logger.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">The IPGPLogger is not registered in the Api Services.</exception>
        public static IPGPLogger GetCurrentApiLogger(this ServicesContainer service)
        {
            var logger = ApiServicesHelper.GetRegisteredService<IPGPLogger>();
            if (logger == null)
            {
                throw new InvalidOperationException("The IPGPLogger is not registered in the ApiServiceHelper.");
            }

            return logger;
        }
    }
}