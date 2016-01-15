using System;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace PGP.Infrastructure.Framework.WebApi.Formatters
{
    /// <summary>
    /// Json formatter.
    /// </summary>
    public class StandardJsonFormatter : JsonMediaTypeFormatter
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StandardJsonFormatter"/> class.
        /// </summary>
        public StandardJsonFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            SerializerSettings.Converters.Add(new StringEnumConverter());
            SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            SerializerSettings.NullValueHandling = NullValueHandling.Include;
            SerializerSettings.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
            SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            SerializerSettings.DateParseHandling = DateParseHandling.DateTime;
            SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
        }

        #endregion Constructors

        #region Methods

        /// <summary>
        /// Sets the default headers for content that will be formatted using this formatter. This method is called from the <see cref="T:System.Net.Http.ObjectContent" /> constructor. This implementation sets the Content-Type header to the value of mediaType if it is not null. If it is null it sets the Content-Type to the default media type of this formatter. If the Content-Type does not specify a charset it will set it using this formatters configured <see cref="T:System.Text.Encoding" />.
        /// </summary>
        /// <param name="type">The type of the object being serialized. See <see cref="T:System.Net.Http.ObjectContent" />.</param>
        /// <param name="headers">The content headers that should be configured.</param>
        /// <param name="mediaType">The authoritative media type. Can be null.</param>
        public override void SetDefaultContentHeaders(Type type, HttpContentHeaders headers, MediaTypeHeaderValue mediaType)
        {
            base.SetDefaultContentHeaders(type, headers, mediaType);
            headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        #endregion Methods
    }
}