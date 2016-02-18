using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PGP.Domain.DomainHelpers;
using PGP.Domain.Users;
using PGP.Infrastructure.Framework.Cryptography;
using PGP.Infrastructure.Framework.Messages.MessageHandlers;
using PGP.Infrastructure.Framework.Repositories;
using PGP.Infrastructure.Framework.Specifications;
using PGP.Infrastructure.Framework.Specifications.Errors;
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
        private IDomainContext m_domainContext;

        private IUserService m_target;

        [TestInitialize]
        public void Initialize()
        {
            var mockRepository = new MockRepository(MockBehavior.Loose);
            m_domainContext = new MemoryDomainContext();
            DomainMessageHelper.MessageHandler = mockRepository.Create<IMessageHandler>().Object;
            m_target = new UserService(new PGPUnitOfWork(m_domainContext), new UserRepository(m_domainContext));


            m_target.SaveEntity(new User()
            {
                FullName = "teste",
                NickName = "Teste2",
                Password = "123456",
                Username = "gabriel@teste.com",
            });

            m_domainContext.SaveContextChanges();
        }

        #region Tests

        [TestMethod]
        public void GetValidUserForLogin_ValidLoginAndPassword_User()
        {
            var user = m_target.GetValidUserForLogin("gabriel@teste.com", "123456");
            Assert.IsNotNull(user);
            Assert.AreEqual("gabriel@teste.com", user.Username);
        }

        [TestMethod]
        public void GetValidUserForLogin_InvalidAndPassword_Null()
        {
            var user = m_target.GetValidUserForLogin("", "123456");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetValidUserForLogin_InvalidPassword_Null()
        {
            var user = m_target.GetValidUserForLogin("gabriel@teste.com", null);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetValidUserForLogin_InvalidLoginAndPassword_Null()
        {
            var user = m_target.GetValidUserForLogin("gabriel@teste.com", "12345");
            Assert.IsNull(user);
        }

        [TestMethod]
        public void RegisterUser_ValidUser_Success()
        {
            var user = m_target.RegisterUser("gabriel@teste1.com", "123456", "Gabriel Teste", "majoras");
            m_domainContext.SaveContextChanges();

            user = m_target.GetValidUserForLogin("gabriel@teste1.com", "123456");
            Assert.IsNotNull(user);
        }

        [TestMethod]
        [ExpectedException(typeof(DomainSpecificationNotSatisfiedException))]
        public void RegisterUser_AlreadyInDatabaseUser_DomainSpecificationNotSatisfiedException()
        {
            var user = m_target.RegisterUser("gabriel@teste.com", "456789", "Gabriel Teste2", "majoras2");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(DomainSpecificationNotSatisfiedException))]
        public void RegisterUser_UserWithInvalidPassword_DomainSpecificationNotSatisfiedException()
        {
            var user = m_target.RegisterUser("gabriel2@teste.com", "12345", "Gabriel Teste2", "majoras2");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(DomainSpecificationNotSatisfiedException))]
        public void RegisterUser_UserWithInvalidUsername_DomainSpecificationNotSatisfiedException()
        {
            var user = m_target.RegisterUser("", "1234566", "Gabriel Teste2", "majoras2");
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(DomainSpecificationNotSatisfiedException))]
        public void SaveEntity_UserWithNullPassword_DomainSpecificationNotSatisfiedException()
        {
            m_target.SaveEntity(new User()
            {
                Password = null,
            });
            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(DomainSpecificationNotSatisfiedException))]
        public void SaveEntity_UserWithEmptyPassword_DomainSpecificationNotSatisfiedException()
        {
            m_target.SaveEntity(new User()
            {
                Password = string.Empty,
            });
            Assert.Fail();
        }

        [TestMethod]
        public void SaveEntity_EditExistingUser_User()
        {
            var user = m_target.GetValidUserForLogin("gabriel@teste.com", "123456");
            user.NickName = "majoras1234";
            m_target.SaveEntity(user);
            m_domainContext.SaveContextChanges();

            user = m_target.GetValidUserForLogin("gabriel@teste.com", "123456");
            Assert.AreEqual("majoras1234", user.NickName);
        }

        #endregion
    }
}
