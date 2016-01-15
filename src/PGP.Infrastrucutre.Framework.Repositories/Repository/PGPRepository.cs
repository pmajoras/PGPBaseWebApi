using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HelperSharp;

namespace PGP.Infrastructure.Framework.Repositories
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class PGPRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Private Properties

        /// <summary>
        /// The m_domain context
        /// </summary>
        private IDomainContext m_domainContext;

        #endregion Private Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PGPRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="domainContext">The domain context.</param>
        public PGPRepository(IDomainContext domainContext)
        {
            ExceptionHelper.ThrowIfNull("domainContext", domainContext);
            m_domainContext = domainContext;
            m_domainContext.RegisterRepository(this);
        }

        #endregion Constructors

        #region Interface Methods

        /// <summary>
        /// Add an entity to this repository
        /// </summary>
        /// <param name="entity">The entity to be added</param>
        public void Add(TEntity entity)
        {
            m_domainContext.RegisterNew(entity);
        }

        /// <summary>
        /// Attach an entity to this repository
        /// </summary>
        /// <param name="entity">The entity to be attached</param>
        public void Attach(TEntity entity)
        {
            m_domainContext.Attach(entity);
        }

        /// <summary>
        /// Befores the delete new item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void BeforeDeleteItem(TEntity entity)
        {
        }

        /// <summary>
        /// Befores the persist new item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void BeforePersistNewItem(TEntity entity)
        {
        }

        /// <summary>
        /// Befores the persist updated item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public virtual void BeforePersistUpdatedItem(TEntity entity)
        {
        }

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public int Count()
        {
            return m_domainContext.CreateQuery<TEntity>().Count();
        }

        /// <summary>
        /// Delete from the repository the passed entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            m_domainContext.RegisterDeleted(entity);
        }

        /// <summary>
        /// Mark the passed entity as an entity to be edited
        /// </summary>
        /// <param name="entity"></param>
        public void Edit(TEntity entity)
        {
            m_domainContext.RegisterChanged(entity);
        }

        /// <summary>
        /// Finds all the entities with the given filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter = null)
        {
            var query = m_domainContext.CreateQuery<TEntity>();

            if (filter != null)
            {
                query.Where(filter);
            }

            return query;
        }

        /// <summary>
        /// Finds all the entities with the given filter.
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <param name="filter">The filter.</param>
        /// <param name="order"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindAll(int offset, int limit, Expression<Func<TEntity, bool>> filter, Expression<Func<IEnumerable<TEntity>, IEnumerable<TEntity>>> order)
        {
            var query = m_domainContext.CreateQuery<TEntity>();

            if (filter != null)
            {
                query.Where(filter);
            }

            return query.Skip(offset).Take(limit);
        }

        /// <summary>
        /// Get an entity from the repository by id.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>
        /// Return an entity, or null case the entity does not exists.
        /// </returns>
        public TEntity GetById(object id)
        {
            return m_domainContext.GetById<TEntity>(id);
        }

        /// <summary>
        /// Sets the repository context.
        /// </summary>
        /// <param name="context">The repository context.</param>
        public virtual void SetContext(IDomainContext context)
        {
            m_domainContext = context;
        }

        #endregion Interface Methods
    }
}