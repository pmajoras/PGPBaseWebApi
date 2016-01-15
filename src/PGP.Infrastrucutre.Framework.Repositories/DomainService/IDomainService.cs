using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PGP.Infrastructure.Framework.Repositories
{
    /// <summary>
    /// The interface that represents a DomainService
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDomainService<TEntity> where TEntity : IEntity
    {
        /// <summary>
        /// Finds all the entities with the given filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter = null);

        /// <summary>
        /// Finds all entities with the given filter.
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
        /// Get an entity by id.
        /// </summary>
        /// <typeparam name="TKey">the type of the id.</typeparam>
        /// <param name="id">The id parameter.</param>
        /// <returns>Return an entity, or null case the entity does not exists.</returns>
        TEntity GetById(object id);

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void SaveEntity(TEntity entity);

        /// <summary>
        /// Saves the entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void SaveEntities(IEnumerable<TEntity> entities);

        /// <summary>
        /// Removes the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void RemoveEntity(object id);

        /// <summary>
        /// Commits the changes to the database.
        /// </summary>
        void Commit();
    }
}