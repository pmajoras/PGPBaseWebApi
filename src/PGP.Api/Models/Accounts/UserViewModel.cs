using PGP.Infrastructure.Framework.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGP.Api.Models.Accounts
{
    public class UserViewModel : IViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}