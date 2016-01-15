using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Framework.WebApi.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ApiServicesHelper
    {
        private static Dictionary<Type, object> s_registeredServices = new Dictionary<Type, object>();

        /// <summary>
        /// Registers the service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service">The service.</param>
        public static void RegisterService<T>(T service)
        {
            RegisterService(typeof(T), service);
        }

        /// <summary>
        /// Registers the service.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="service">The service.</param>
        public static void RegisterService(Type type, object service)
        {
            if (s_registeredServices.ContainsKey(type))
            {
                s_registeredServices.Remove(type);
            }
            s_registeredServices.Add(type, service);
        }

        /// <summary>
        /// Gets the registered service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetRegisteredService<T>() where T : class
        {
            object service = null;
            s_registeredServices.TryGetValue(typeof(T), out service);

            return service as T;
        }
    }
}
