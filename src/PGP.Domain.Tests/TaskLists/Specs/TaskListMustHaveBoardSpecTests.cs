using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Domain.DomainHelpers;
using PGP.Domain.TaskLists;
using PGP.Domain.TaskLists.Specs;
using PGP.Infrastructure.Framework.Messages.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Tests.TaskLists.Specs
{
    [TestClass]
    public class TaskListMustHaveBoardSpecTests
    {
        private TaskListMustHaveBoardSpec m_target = new TaskListMustHaveBoardSpec();

        [TestInitialize]
        public void Initialize()
        {
            Moq.MockRepository mockRepo = new Moq.MockRepository(Moq.MockBehavior.Loose);
            DomainMessageHelper.MessageHandler = mockRepo.Create<IMessageHandler>().Object;
        }

        #region Tests

        [TestMethod]
        public void IsSatisfiedBy_TaskListWithBoard_True()
        {
            Assert.IsTrue(m_target.IsSatisfiedBy(new TaskList() { Board = new Boards.Board() }));
        }

        [TestMethod]
        public void IsSatisfiedBy_TaskListWithoutBoard_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new TaskList()));
        }

        [TestMethod]
        public void IsSatisfiedBy_TaskListWithoutBoardAndWithBoardId_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new TaskList() { BoardId = 5 }));
        }

        #endregion
    }
}
