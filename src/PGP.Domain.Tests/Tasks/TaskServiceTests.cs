using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Domain.Tasks;
using PGP.Infrastructure.Framework.Repositories;
using PGP.Infrastructure.Repositories.EF.Repositories.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Tests.Tasks
{
    [TestClass]
    public class TaskServiceTests
    {
        private ITaskService m_target;

        [TestInitialize]
        public void Initialize()
        {
            var context = new MemoryDomainContext();
            m_target = new TaskService(new PGPUnitOfWork(context), new TaskRepository(context));
        }


        #region Tests



        #endregion
    }
}
