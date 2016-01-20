using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Infrastructure.Framework.Tests.DomainContext
{
    /// <summary>
    /// Test class for MemoryDomainContext
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable")]
    [TestClass]
    public class MemoryDomainContextTest
    {
        #region Private properties

        private MemoryDomainContext m_target;

        #endregion Private properties

        #region Initialization

        /// <summary>
        /// Initialize the Tests for the class MemoryDomainContext
        /// </summary>
        [TestInitialize]
        public void InitializeTests()
        {
            m_target = new MemoryDomainContext();
        }

        #endregion Initialization

        #region Tests

        #region RegisterRepository

        /// <summary>
        /// MethodName_Parameter_Expected
        /// </summary>
        [TestMethod]
        public void RegisterRepository_Repository_Success()
        {
            var mock = new Mock<IRepository<PGPEntity>>();
            m_target.RegisterRepository(mock.Object);
        }

        /// <summary>
        /// MethodName_Parameter_Expected
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterRepository_Null_ArgumentNullException()
        {
            m_target.RegisterRepository<PGPEntity>(null);
            Assert.Fail();
        }

        #endregion RegisterRepository

        #region RegisterNew

        /// <summary>
        /// MethodName_Parameter_Expected.
        /// </summary>
        [TestMethod]
        public void RegisterNew_EntityBase_Success()
        {
            m_target.RegisterNew(new PGPEntity());
        }

        /// <summary>
        /// Tests the method RegisterNew with parameter Null and the expected result is ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterNew_Null_ArgumentNullException()
        {
            m_target.RegisterNew<PGPEntity>(null);
            Assert.Fail();
        }

        #endregion RegisterNew

        #region Attach

        /// <summary>
        /// Tests the method Attach with parameter EntityBase and the expected result is Success
        /// </summary>
        [TestMethod]
        public void Attach_EntityBase_Success()
        {
            m_target.Attach(new PGPEntity());
        }

        /// <summary>
        /// Tests the method Attach with parameter Null and the expected result is ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Attach_Null_ArgumentNullException()
        {
            m_target.Attach<PGPEntity>(null);
            Assert.Fail();
        }

        #endregion Attach

        #region RegisterDeleted

        /// <summary>
        /// Tests the method RegisterDeleted with parameter EntityBase and the expected result is Success
        /// </summary>
        [TestMethod]
        public void RegisterDeleted_EntityBase_Success()
        {
            var entity = new PGPEntity();
            m_target.Attach(entity);
            m_target.RegisterDeleted(entity);
        }

        /// <summary>
        /// Tests the method RegisterDeleted with parameter Null and the expected result is ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterDeleted_Null_ArgumentNullException()
        {
            m_target.RegisterDeleted<PGPEntity>(null);
            Assert.Fail();
        }

        #endregion RegisterDeleted

        #region RegisterChanged

        /// <summary>
        /// Tests the method RegisterChanged with parameter EntityBase and the expected result is Success
        /// </summary>
        [TestMethod]
        public void RegisterChanged_EntityBase_Success()
        {
            var entity = new PGPEntity();
            m_target.Attach(entity);
            entity.Id = 5;
            m_target.RegisterChanged(entity);
        }

        /// <summary>
        /// Tests the method RegisterChanged with parameter Null and the expected result is ArgumentNullException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RegisterChanged_Null_ArgumentNullException()
        {
            m_target.RegisterChanged<PGPEntity>(null);
            Assert.Fail();
        }

        #endregion RegisterChanged

        #region CreateQuery

        /// <summary>
        /// Tests the method CreateQuery with parameter Default and the expected result is Entities
        /// </summary>
        [TestMethod]
        public void CreateQuery_Default_Entities()
        {
            var initialList = m_target.CreateQuery<PGPEntity>().ToList();

            var entityToAdd = new PGPEntity();
            m_target.RegisterNew(entityToAdd);
            m_target.SaveContextChanges();

            var finalList = m_target.CreateQuery<PGPEntity>().ToList();

            Assert.AreEqual(initialList.Count + 1, finalList.Count);
            Assert.IsTrue(finalList.Any(x => x.Id == entityToAdd.Id));
        }

        /// <summary>
        /// Tests the method CreateQuery with parameter UnexistingQuery and the expected result is None
        /// </summary>
        [TestMethod]
        public void CreateQuery_UnexistingQuery_None()
        {
            var initialList = m_target.CreateQuery<PGPEntity>().ToList();

            var entityToAdd = new PGPEntity();
            m_target.RegisterNew(entityToAdd);
            m_target.SaveContextChanges();

            var finalList = m_target.CreateQuery<PGPEntity>()
                .Where(x => x.Id == -1).ToList();

            Assert.AreEqual(initialList.Count, finalList.Count);
        }

        #endregion CreateQuery

        #region GetById

        /// <summary>
        /// Tests the method GetById with parameter ValidId and the expected result is BaseEntity
        /// </summary>
        [TestMethod]
        public void GetById_ValidId_BaseEntity()
        {
            var initialList = m_target.CreateQuery<PGPEntity>().ToList();

            var entityToAdd = new PGPEntity();
            m_target.RegisterNew(entityToAdd);
            m_target.SaveContextChanges();

            var entityFoundById = m_target.GetById<PGPEntity>(entityToAdd.Id);

            Assert.IsNotNull(entityFoundById);
            Assert.AreEqual(entityFoundById.Id, entityToAdd.Id);
        }

        /// <summary>
        /// Tests the method GetById with parameter InvalidId and the expected result is BaseEntity
        /// </summary>
        [TestMethod]
        public void GetById_InvalidId_BaseEntity()
        {
            var initialList = m_target.CreateQuery<PGPEntity>().ToList();

            var entityToAdd = new PGPEntity();
            m_target.RegisterNew(entityToAdd);
            m_target.SaveContextChanges();

            var entityFoundById = m_target.GetById<PGPEntity>(-1);

            Assert.IsNull(entityFoundById);
        }

        #endregion GetById

        #region BeginTransaction

        /// <summary>
        /// Tests the method BeginTransaction with parameter Default and the expected result is HasTransaction
        /// </summary>
        [TestMethod]
        public void BeginTransaction_Default_HasTransaction()
        {
            m_target.BeginTransaction();
            Assert.IsTrue(m_target.HasPendingTransaction);
        }

        /// <summary>
        /// Tests the method BeginTransaction with parameter DoubleCall and the expected result is NothingOnSecondCall
        /// </summary>
        [TestMethod]
        public void BeginTransaction_DoubleCall_NothingOnSecondCall()
        {
            m_target.BeginTransaction();
            m_target.BeginTransaction();
            Assert.IsTrue(m_target.HasPendingTransaction);
        }

        #endregion BeginTransaction

        #region CommitTransaction

        /// <summary>
        /// Tests the method CommitTransaction with parameter ValidTransaction and the expected result is Success
        /// </summary>
        [TestMethod]
        public void CommitTransaction_ValidTransaction_Success()
        {
            m_target.BeginTransaction();
            var entityToAdd = new PGPEntity();
            m_target.RegisterNew(entityToAdd);
            m_target.CommitTransaction();

            var entityFoundById = m_target.GetById<PGPEntity>(entityToAdd.Id);

            Assert.IsNotNull(entityFoundById);
        }

        /// <summary>
        /// Tests the method CommitTransaction with parameter TransactionNotStarted and the expected result is InvalidOperationException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CommitTransaction_TransactionNotStarted_InvalidOperationException()
        {
            var entityToAdd = new PGPEntity();
            m_target.RegisterNew(entityToAdd);
            m_target.CommitTransaction();

            Assert.Fail();
        }

        #endregion CommitTransaction

        #region RoolbackTransaction

        /// <summary>
        /// Tests the method RoolbackTransaction with parameter TransactionStarted and the expected result is Success
        /// </summary>
        [TestMethod]
        public void RoolbackTransaction_TransactionStarted_Success()
        {
            m_target.BeginTransaction();
            var entityToAdd = new PGPEntity();
            m_target.RegisterNew(entityToAdd);
            m_target.RoolbackTransaction();

            var entityFoundById = m_target.GetById<PGPEntity>(entityToAdd.Id);

            Assert.IsNull(entityFoundById);
        }

        /// <summary>
        /// Tests the method RoolbackTransaction with parameter TransactionNotStarted and the expected result is InvalidOperationException
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RoolbackTransaction_TransactionNotStarted_InvalidOperationException()
        {
            var entityToAdd = new PGPEntity();
            m_target.RegisterNew(entityToAdd);
            m_target.RoolbackTransaction();

            Assert.Fail();
        }

        #endregion RoolbackTransaction

        #endregion Tests
    }
}