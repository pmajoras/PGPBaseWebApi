using PGP.Api.Models.Accounts;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using PGP.Infrastructure.Framework.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using PGP.Infrastructure.Framework.WebApi.ActionFilters;
using PGP.Api.ApiMessageHandlers;
using PGP.Infrastructure.Framework.WebApi.Models;

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