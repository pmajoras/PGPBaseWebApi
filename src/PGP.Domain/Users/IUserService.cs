using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Domain.Users
{
    public interface IUserService : IDomainService<User>
    {
        /// <summary>
        /// Gets the valid user for login.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        User GetValidUserForLogin(string username, string password);

        /// <summary>
        /// Registers the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="fullName">The full name.</param>
        /// <param name="nickName">Name of the nick.</param>
        User RegisterUser(string username, string password, string fullName, string nickName);
    }
}
