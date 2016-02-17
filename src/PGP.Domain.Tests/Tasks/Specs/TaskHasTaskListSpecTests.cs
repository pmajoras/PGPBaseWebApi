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
    public class TaskHasTaskListSpecTests
    {

        private TaskHasTaskListSpec m_target = new TaskHasTaskListSpec();

        [TestInitialize]
        public void Initialize()
        {
            Moq.MockRepository mockRepo = new Moq.MockRepository(Moq.MockBehavior.Loose);
            DomainMessageHelper.MessageHandler = mockRepo.Create<IMessageHandler>().Object;
        }

        #region Tests

        [TestMethod]
        public void IsSatisfiedBy_TaskWithTaskList_True()
        {
            Assert.IsTrue(m_target.IsSatisfiedBy(new Task() { TaskList = new TaskLists.TaskList() }));
        }

        [TestMethod]
        public void IsSatisfiedBy_TaskWithoutTaskList_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new Task()));
        }

        [TestMethod]
        public void IsSatisfiedBy_TaskWithoutTaskListAndWithTaskListId_False()
        {
            Assert.IsFalse(m_target.IsSatisfiedBy(new Task() { TaskListId = 5 }));
        }

        #endregion
    }
}
