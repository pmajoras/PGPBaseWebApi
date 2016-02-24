using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Domain.TaskLists;
using PGP.Infrastructure.Framework.Repositories;
using PGP.Infrastructure.Repositories.EF.Repositories.TaskLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Tests.TaskLists
{
    [TestClass]
    public class TaskListServiceTests
    {

        private ITaskListService m_target;

        [TestInitialize]
        public void Initialize()
        {
            var context = new MemoryDomainContext();
            m_target = new TaskListService(new PGPUnitOfWork(context), new TaskListRepository(context));
        }

        #region Tests

        #endregion
    }
}
