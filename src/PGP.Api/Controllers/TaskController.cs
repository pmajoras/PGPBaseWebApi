using PGP.Domain.Tasks;
using PGP.Infrastructure.Framework.WebApi.Controllers;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PGP.Api.Controllers
{

    [RoutePrefix("api/tasks")]
    public class TaskController : PGPApiController
    {
        private ITaskService m_taskService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        public TaskController(ITaskService taskService)
        {
            m_taskService = taskService;
        }

        [Route("tasks")]
        [HttpGet]
        public ApiResult<ApiResponse> GetTasks()
        {
            return ApiOkResult();
        }
    }
}