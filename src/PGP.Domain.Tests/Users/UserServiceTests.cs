using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Domain.Users;
using PGP.Infrastructure.Framework.Repositories;
using PGP.Infrastructure.Repositories.EF.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Tests.Users
{
    [TestClass]
    public class UserServiceTests
    {
        private IUserService m_target;

        [TestInitialize]
        public void Initialize()
        {
            var context = new MemoryDomainContext();
            m_target = new UserService(new PGPUnitOfWork(context), new UserRepository(context));
        }

        #region Tests

        #endregion
    }
}
