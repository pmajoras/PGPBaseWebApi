using System.Web.Http;
using PGP.Api.Models.Accounts;
using PGP.Infrastructure.Framework.WebApi.ActionFilters;
using PGP.Infrastructure.Framework.WebApi.Controllers;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using PGP.Infrastructure.Repositories.EF;
using System.Linq;
using System;

namespace PGP.Api.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : PGPApiController
    {
        public AccountsController()
        {
        }

        [Route("Users")]
        [HttpGet]
        [ApiLog]
        public ApiResult<ApiResponse> GetUsers()
        {
            return ApiOkResult(new UserViewModel() { Name = "Teste", Email = "teste2" });
        }

        [HttpPost]
        public ApiResult<ApiResponse> SaveUser(UserViewModel entity)
        {
            return ApiOkResult();
        }

        [HttpPut]
        public ApiResult<ApiResponse> UpdateUser(UserViewModel entity)
        {
            return ApiOkResult();
        }

        [HttpDelete]
        public ApiResult<ApiResponse> RemoveUser(int id)
        {
            return ApiOkResult();
        }
    }
}