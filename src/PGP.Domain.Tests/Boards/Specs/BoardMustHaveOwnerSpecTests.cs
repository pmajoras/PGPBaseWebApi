using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Domain.Boards;
using PGP.Domain.Boards.Specs;
using PGP.Domain.DomainHelpers;
using PGP.Domain.Users;
using PGP.Infrastructure.Framework.Messages.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Tests.Boards.Specs
{
    [TestClass]
    public class BoardMustHaveOwnerSpecTests
    {
        private BoardMustHaveOwnerSpec m_target = new BoardMustHaveOwnerSpec();

        [TestInitialize]
        public void Initialize()
        {
            Moq.MockRepository mockRepo = new Moq.MockRepository(Moq.MockBehavior.Loose);
            DomainMessageHelper.MessageHandler = mockRepo.Create<IMessageHandler>().Object;
        }

        #region Tests

        [TestMethod]
        public void IsSatisfiedBy_BoardWithOwner_True()
        {
            Assert.IsTrue(m_target.IsSatisfiedBy(new Board() { Owner = new User() }));
        }

        [TestMethod]
        public void IsSatisfiedBy_BoardWithoutOwner_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new Board()));
        }

        #endregion
    }
}
