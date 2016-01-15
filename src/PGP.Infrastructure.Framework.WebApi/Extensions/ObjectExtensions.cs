using System;
using Newtonsoft.Json;
using PGP.Infrastructure.Framework.WebApi.Helpers;

namespace PGP.Infrastructure.Framework.WebApi.Extensions
{
    /// <summary>
    ///
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Converts the object to JSON string
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        public static string ToJSON(this object obj)
        {
            try
            {
                return JsonConvert.SerializeObject(obj, JsonHelper.SetDefaultJsonSerializerSettings(new JsonSerializerSettings()));
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}