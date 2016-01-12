using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Infrastructure.Framework.WebApi.Models;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

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
        /// APIs the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller">The controller.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public virtual ApiResult<ApiResponse> ApiOkResult<T>(T content) where T : IViewModel
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
