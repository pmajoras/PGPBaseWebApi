using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGP.Domain.Boards;
using PGP.Infrastructure.Framework.Repositories;
using PGP.Infrastructure.Repositories.EF.Repositories.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Tests.Boards
{
    [TestClass]
    public class BoardServiceTests
    {
        private IBoardService m_target;

        [TestInitialize]
        public void Initialize()
        {
            var context = new MemoryDomainContext();
            m_target = new BoardService(new PGPUnitOfWork(context), new BoardRepository(context));
        }

        #region Tests

        #endregion
    }
}
