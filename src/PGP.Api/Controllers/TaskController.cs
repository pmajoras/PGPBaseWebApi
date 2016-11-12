using PGP.Domain.Tasks;
using PGP.Infrastructure.Framework.WebApi.ActionFilters;
using PGP.Infrastructure.Framework.WebApi.Controllers;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace PGP.Api.Controllers
{

    [RoutePrefix("api/tasks")]
    public class TaskController : PGPApiController
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        public TaskController()
        {
        }


        [HttpGet]
        [Route("")]
        [ApiLog]
        public ApiResult<ApiResponse> GetTasks([FromUri]string exception = "", [FromUri]string timeout = "")
        {
            if (!string.IsNullOrEmpty(exception))
            {
                throw new NullReferenceException("There was a null reference exception on the code.");
            }

            if (!string.IsNullOrEmpty(timeout))
            {
                Thread.Sleep(11000);
            }

            return ApiOkResult();
        }
    }
}