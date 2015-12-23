using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Framework.Repositories
{
    /// <summary>
    /// The Interface that indicates that the object is a <see cref=">IDomainContext"/>
    /// </summary>
    public interface IDomainContext : IDisposable
    {
        /// <summary>
        /// Registers the entity as a new entity in the context.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="entity">The entity to be registered.</param>
        void RegisterRepository<TRepository>(IRepository<TRepository> repository) where TRepository : class, IEntity;

        /// <summary>
        /// Registers the entity as a new entity in the context.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="entity">The entity to be registered.</param>
        void RegisterNew<TEntity>(TEntity entity) where TEntity : class, IEntity;

        /// <summary>
        /// Attach an entity to the context.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="entity">The entity to be attached.</param>
        void Attach<TEntity>(TEntity entity) where TEntity : class, IEntity;

        /// <summary>
        /// Registers entity as a deleted entity in the context.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="entity">The entity to be deleted.</param>
        void RegisterDeleted<TEntity>(TEntity entity) where TEntity : class, IEntity;

        /// <summary>
        /// Registers the entity as a changed entity in the context.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        void RegisterChanged<TEntity>(TEntity entity) where TEntity : class, IEntity;

        /// <summary>
        /// Creates a query to be filtered.
        /// </summary>
        /// <typeparam name="TEntity">Type of the entity.</typeparam>
        /// <returns></returns>
        IQueryable<TEntity> CreateQuery<TEntity>() where TEntity : class, IEntity;

        TEntity GetById<TEntity>(object id) where TEntity : class, IEntity;

        /// <summary>
        /// Begin a transaction
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// Commit the oppened transaction
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// Rollback the oppened transaction
        /// </summary>
        void RoolbackTransaction();

        /// <summary>
        /// Save the context changes and commit, in case of error this method is supposed to call the <see cref="RoolbackTransaction"/> method.
        /// </summary>
        void SaveContextChanges();

        /// <summary>
        /// Clear the context, removes all entities that are attached in the context.
        /// </summary>
        void ClearContext();
    }
}
