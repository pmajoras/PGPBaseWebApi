using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using PGP.Infrastructure.Framework.Messages;

namespace PGP.Infrastructure.Framework.WebApi.HttpActionResults
{
    public static class ApiResultsHelper
    {
        /// <summary>
        /// Creates the API result.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="request">The request.</param>
        /// <param name="contentObject">The content object.</param>
        /// <param name="formatter">The formatter.</param>
        /// <param name="statusCode">The status code.</param>
        /// <returns></returns>
        public static ApiResult<TContent> CreateApiResult<TContent>(HttpRequestMessage request, TContent contentObject,
            HttpStatusCode? statusCode = null, MediaTypeFormatter formatter = null)
        {
            return new ApiResult<TContent>(request, contentObject, formatter, statusCode);
        }

        /// <summary>
        /// Creates the API result from exception.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="statusCode">The status code.</param>
        /// <param name="formatter">The formatter.</param>
        /// <returns></returns>
        public static ApiResult<ApiResponse> CreateApiResultFromException(HttpRequestMessage request,
            Exception exception,
            int errorCode,
            string errorMessage = null,
            HttpStatusCode? statusCode = null,
            MediaTypeFormatter formatter = null)
        {
            errorMessage = errorMessage ?? exception.Message;

            return new ApiResult<ApiResponse>(request, new ApiResponse(new ErrorContent(errorMessage, errorCode)), formatter, statusCode);
        }
    }
}