using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGP.Domain.Users;
using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Infrastructure.Repositories.EF.Repositories.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRepository : EFGenericRepository<User>, IUserRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserRepository(IDomainContext context)
            : base(context)
        {

        }

        #endregion
    }
}
