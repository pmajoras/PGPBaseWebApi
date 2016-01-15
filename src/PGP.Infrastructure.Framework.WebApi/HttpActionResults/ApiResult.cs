using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Http;
using PGP.Infrastructure.Framework.WebApi.Formatters;

namespace PGP.Infrastructure.Framework.WebApi.HttpActionResults
{
    /// <summary>
    /// The HttpActionResult that can be used for general errors with content in the response.
    /// </summary>
    public class ApiResult<T> : IHttpActionResult
    {
        #region Protected Properties

        /// <summary>
        /// The Request.
        /// </summary>
        protected HttpRequestMessage m_request;

        /// <summary>
        /// The formatter that will be used.
        /// </summary>
        protected MediaTypeFormatter m_formatter;

        /// <summary>
        /// The object that will be sent in the content of the response.
        /// </summary>
        protected T m_contentObject;

        /// <summary>
        /// The default HttpStatusCode, if null is passed as parameter will be used 200.
        /// </summary>
        protected HttpStatusCode m_defaultStatusCode;

        #endregion Protected Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResult{T}"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="contentObject">The content object.</param>
        /// <param name="formatter">The formatter.</param>
        /// <param name="statusCode">The status code.</param>
        /// <exception cref="System.ArgumentNullException">
        /// request
        /// or
        /// errorObject
        /// </exception>
        public ApiResult(HttpRequestMessage request, T contentObject,
            MediaTypeFormatter formatter = null, HttpStatusCode? statusCode = null)
        {
            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            if (contentObject == null)
            {
                throw new ArgumentNullException("errorObject");
            }

            m_request = request;
            m_contentObject = contentObject;

            m_defaultStatusCode = statusCode ?? HttpStatusCode.OK;
            m_formatter = formatter ?? new StandardJsonFormatter();
        }

        #endregion Constructors

        /// <summary>
        /// Executes the asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public Task<HttpResponseMessage> ExecuteAsync(System.Threading.CancellationToken cancellationToken)
        {
            var response = m_request.CreateResponse(m_defaultStatusCode, m_contentObject, m_formatter);
            return Task.FromResult(response);
        }
    }
}