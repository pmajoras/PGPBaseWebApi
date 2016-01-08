using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using PGP.Infrastructure.Framework.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
