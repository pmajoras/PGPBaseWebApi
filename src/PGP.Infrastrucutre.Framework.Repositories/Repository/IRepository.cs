using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PGP.Infrastructure.Framework.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Befores the persist new item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void BeforePersistNewItem(object entity);

        /// <summary>
        /// Befores the delete new item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void BeforeDeleteItem(object entity);

        /// <summary>
        /// Befores the persist updated item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void BeforePersistUpdatedItem(object entity);
    }

    /// <summary>
    /// An interface that represents that the class is a repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IRepository<TEntity> : IRepository where TEntity : IEntity
    {
        /// <summary>
        /// Sets the repository context.
        /// </summary>
        /// <param name="context">The repository context.</param>
        void SetContext(IDomainContext context);

        /// <summary>
        /// Finds all the entities with the given filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Finds all entities.
        /// </summary>
        /// <param name="offset">The offset.</param>
        /// <param name="limit">The limit.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll(int offset, int limit, Expression<Func<TEntity, bool>> filter, Expression<Func<IEnumerable<TEntity>, IEnumerable<TEntity>>> order);

        /// <summary>
        /// Counts this instance.
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// Get an entity from the repository by id.
        /// </summary>
        /// <typeparam name="TKey">the type of the id.</typeparam>
        /// <param name="id">The id parameter.</param>
        /// <returns>Return an entity, or null case the entity does not exists.</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Add an entity to this repository
        /// </summary>
        /// <param name="entity">The entity to be added</param>
        void Add(TEntity entity);

        /// <summary>
        /// Attach an entity to this repository
        /// </summary>
        /// <param name="entity">The entity to be attached</param>
        void Attach(TEntity entity);

        /// <summary>
        /// Mark the passed entity as an entity to be edited
        /// </summary>
        /// <param name="entity"></param>
        void Edit(TEntity entity);

        /// <summary>
        /// Delete from the repository the passed entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);
    }
}