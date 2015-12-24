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
    public static class ControllersExtensions
    {
        /// <summary>
        /// APIs the ok.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns></returns>
        public static ApiResult<ApiResponse> ApiOk(this ApiController controller)
        {
            return new ApiResult<ApiResponse>(controller.Request, new ApiResponse());
        }

        /// <summary>
        /// APIs the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller">The controller.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static ApiResult<ApiResponse> ApiOk<T>(this ApiController controller, T content) where T : IViewModel
        {
            return new ApiResult<ApiResponse>(controller.Request, new ApiResponse(content));
        }

        /// <summary>
        /// APIs the response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="controller">The controller.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static ApiResult<ApiResponse> ApiBadRequest<T>(this ApiController controller, ErrorContent error) where T : IViewModel
        {
            return new ApiResult<ApiResponse>(controller.Request, new ApiResponse(error), null, HttpStatusCode.BadRequest);
        }
    }
}
