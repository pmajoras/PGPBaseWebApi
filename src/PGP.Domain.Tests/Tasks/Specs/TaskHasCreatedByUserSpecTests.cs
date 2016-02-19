using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Domain.DomainHelpers;
using PGP.Domain.Tasks;
using PGP.Domain.Tasks.Specs;
using PGP.Infrastructure.Framework.Messages.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGP.Domain.Tests.Tasks.Specs
{
    [TestClass]
    public class TaskHasCreatedByUserSpecTests
    {
        private TaskHasCreatedByUserSpec m_target = new TaskHasCreatedByUserSpec();

        [TestInitialize]
        public void Initialize()
        {
            Moq.MockRepository mockRepo = new Moq.MockRepository(Moq.MockBehavior.Loose);
            DomainMessageHelper.MessageHandler = mockRepo.Create<IMessageHandler>().Object;
        }

        #region Tests

        [TestMethod]
        public void IsSatisfiedBy_TaskWithUser_True()
        {
            Assert.IsTrue(m_target.IsSatisfiedBy(new Task() { CreatedByUser = new Domain.Users.User() }));
        }

        [TestMethod]
        public void IsSatisfiedBy_TaskWithoutUser_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new Task()));
        }

        [TestMethod]
        public void IsSatisfiedBy_TaskWithoutUserAndWithCreatedByUserId_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new Task() { CreatedByUserId = 5 }));
        }

        #endregion
    }
}
