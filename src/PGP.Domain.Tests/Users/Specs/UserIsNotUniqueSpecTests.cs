using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Domain.DomainHelpers;
using PGP.Domain.Users;
using PGP.Domain.Users.Specs;
using PGP.Infrastructure.Framework.Messages.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Tests.Users.Specs
{
    [TestClass]
    public class UserIsNotUniqueSpecTests
    {
        private UserIsNotUniqueSpec m_target;

        [TestInitialize]
        public void Initialize()
        {
            var users = new List<User>()
            {
                new User() { Username = "teste@teste.com" },
                new User() { Username = "teste1@teste.com"}
            };

            m_target = new UserIsNotUniqueSpec(users);
            Moq.MockRepository mockRepo = new Moq.MockRepository(Moq.MockBehavior.Loose);
            DomainMessageHelper.MessageHandler = mockRepo.Create<IMessageHandler>().Object;
        }

        #region Tests

        [TestMethod]
        public void IsSatisfiedBy_AlreadyRegisteredUserName_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new User() { Username = "teste@teste.com" }));
        }

        [TestMethod]
        public void IsSatisfiedBy_UserWithNullUserName_True()
        {
            Assert.IsTrue(m_target.IsSatisfiedBy(new User() { Username = null }));
        }

        [TestMethod]
        public void IsSatisfiedBy_UserWithEmptyUserName_True()
        {
            Assert.IsTrue(m_target.IsSatisfiedBy(new User() { Username = string.Empty }));
        }

        [TestMethod]
        public void IsSatisfiedBy_UserWithNormalUserName_True()
        {
            Assert.IsTrue(m_target.IsSatisfiedBy(new User() { Username = "teste3@teste.com" }));
        }

        #endregion
    }
}
