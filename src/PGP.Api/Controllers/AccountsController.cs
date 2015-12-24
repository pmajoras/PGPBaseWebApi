using PGP.Api.Models.Accounts;
using PGP.Infrastructure.Framework.WebApi.HttpActionResults;
using PGP.Infrastructure.Framework.WebApi.Models.Responses;
using PGP.Infrastructure.Framework.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PGP.Api.Controllers
{
    public class AccountsController : ApiController
    {
        public AccountsController()
        {

        }

        [HttpGet]
        public ApiResult<ApiResponse> GetUsers()
        {
            return this.ApiOk(new UserViewModel() { Name = "Teste", Email = "teste2" });
        }

        [HttpPost]
        public ApiResult<ApiResponse> SaveUser(UserViewModel entity)
        {

            return this.ApiOk();
        }

        [HttpPut]
        public ApiResult<ApiResponse> UpdateUser(UserViewModel entity)
        {

            return this.ApiOk();
        }

        [HttpDelete]
        public ApiResult<ApiResponse> RemoveUser(int id)
        {

            return this.ApiOk();
        }
    }
}