using System.Net;
using System.Web.Http;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Infrastructure.Framework.WebApi.Models;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using System.Collections.Generic;

namespace PGP.Infrastructure.Framework.WebApi.Controllers
{
    /// <summary>
    ///
    /// </summary>
    public class PGPApiController : ApiController
    {
        /// <summary>
        /// APIs the ok.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns></returns>
        protected virtual ApiResult<ApiResponse> ApiOkResult()
        {
            return new ApiResult<ApiResponse>(Request, new ApiResponse());
        }

        /// <summary>
        /// APIs the ok result.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public virtual ApiResult<ApiResponse> ApiOkResult(object content)
        {
            return new ApiResult<ApiResponse>(Request, new ApiResponse(content));
        }

        /// <summary>
        /// APIs the response.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public virtual ApiResult<ApiResponse> ApiBadRequestResult(ErrorContent error)
        {
            return new ApiResult<ApiResponse>(Request, new ApiResponse(error), null, HttpStatusCode.BadRequest);
        }
    }
}