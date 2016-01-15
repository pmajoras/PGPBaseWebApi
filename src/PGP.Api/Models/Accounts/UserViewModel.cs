using PGP.Infrastructure.Framework.WebApi.Models;

namespace PGP.Api.Models.Accounts
{
    public class UserViewModel : IViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }
}