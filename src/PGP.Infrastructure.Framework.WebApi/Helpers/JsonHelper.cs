using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace PGP.Infrastructure.Framework.WebApi.Helpers
{
    /// <summary>
    ///
    /// </summary>
    public static class JsonHelper
    {
        /// <summary>
        /// Sets the default jsonSerializer settings.
        /// </summary>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <returns></returns>
        public static JsonSerializerSettings SetDefaultJsonSerializerSettings(JsonSerializerSettings serializerSettings)
        {
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            serializerSettings.Converters.Add(new StringEnumConverter());
            serializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            serializerSettings.NullValueHandling = NullValueHandling.Include;
            serializerSettings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
            serializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            serializerSettings.DateParseHandling = DateParseHandling.DateTime;
            serializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;

            return serializerSettings;
        }
    }
}