using System;

namespace PGP.Infrastructure.Framework.Repositories
{
    /// <summary>
    /// Is the PGP implementation of Unit Of Work Pattern
    /// </summary>
    public class PGPUnitOfWork : IUnitOfWork
    {
        #region Protected Properties

        /// <summary>
        /// The m_disposed
        /// </summary>
        protected bool m_disposed = false;

        /// <summary>
        /// The DomainContext of the UnitOfWork
        /// </summary>
        protected IDomainContext m_domainContext;

        #endregion Protected Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PGPUnitOfWork"/> class.
        /// </summary>
        /// <param name="domainContext">The domain context.</param>
        public PGPUnitOfWork(IDomainContext domainContext)
        {
            m_domainContext = domainContext;
        }

        #endregion Constructors

        #region Inteface Methods

        /// <summary>
        /// Open and commit a transaction of this <see cref="IUnitOfWork" /> instance to the database
        /// </summary>
        public virtual void Commit()
        {
            m_domainContext.SaveContextChanges();
        }

        /// <summary>
        /// Rollbacks the openned transaction
        /// </summary>
        public virtual void Rollback()
        {
            m_domainContext.RoolbackTransaction();
        }

        /// <summary>
        /// Discards the changes of this <see cref="IUnitOfWork" /> instance.
        /// </summary>
        public virtual void DiscardChanges()
        {
            m_domainContext.ClearContext();
        }

        #endregion Inteface Methods

        #region Dispose

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_domainContext.Dispose();
                }

                // Dispose unmanaged managed resources.
                m_disposed = true;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}