using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Domain.DomainHelpers;
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
    public class UserHasValidPasswordSpecTests
    {
        private UserHasValidPasswordSpec m_target = new UserHasValidPasswordSpec();

        [TestInitialize]
        public void Initialize()
        {
            Moq.MockRepository mockRepo = new Moq.MockRepository(Moq.MockBehavior.Loose);
            DomainMessageHelper.MessageHandler = mockRepo.Create<IMessageHandler>().Object;
        }

        #region Tests

        [TestMethod]
        public void IsSatisfiedBy_EmptyPassword_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new Domain.Users.User() { Password = string.Empty }));
        }

        [TestMethod]
        public void IsSatisfiedBy_NullPassword_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new Domain.Users.User() { Password = null }));
        }

        [TestMethod]
        public void IsSatisfiedBy_LowLengthPassword_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new Domain.Users.User() { Password = "12345" }));
        }

        [TestMethod]
        public void IsSatisfiedBy_HighLengthPassword_True()
        {
            Assert.IsTrue(m_target.IsSatisfiedBy(new Domain.Users.User() { Password = "123456789123456789123456789123456789" }));
        }

        [TestMethod]
        public void IsSatisfiedBy_NormalPassword_True()
        {
            Assert.IsTrue(m_target.IsSatisfiedBy(new Domain.Users.User() { Password = "123456789123456789123456789123456789" }));
        }

        #endregion
    }
}
