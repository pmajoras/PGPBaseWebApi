using System.Web.Http;
using PGP.Api.Models.Accounts;
using PGP.Infrastructure.Framework.WebApi.ActionFilters;
using PGP.Infrastructure.Framework.WebApi.Controllers;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;

namespace PGP.Api.Controllers
{
    public class AccountsController : PGPApiController
    {
        public AccountsController()
        {
        }

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