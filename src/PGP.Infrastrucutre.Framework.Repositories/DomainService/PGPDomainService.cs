using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using HelperSharp;
using KissSpecifications;
using KissSpecifications.Commons;
using PGP.Infrastructure.Framework.Commons.DomainSpecifications;
using PGP.Infrastructure.Framework.Specifications;

namespace PGP.Infrastructure.Framework.Repositories
{
    /// <summary>
    /// The PGP Domain Service.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class PGPDomainService<TEntity> : IDomainService<TEntity> where TEntity : IEntity
    {
        #region Protected Properties

        /// <summary>
        /// The Unit of Work Implementation
        /// </summary>
        protected IUnitOfWork m_unitOfWork;

        /// <summary>
        /// The m_repository used by this DomainService
        /// </summary>
        protected IRepository<TEntity> m_repository;

        #endregion Protected Properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PGPDomainService{TEntity}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository.</param>
        public PGPDomainService(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            ExceptionHelper.ThrowIfNull("unitOfWork", unitOfWork);
            ExceptionHelper.ThrowIfNull("repository", repository);

            m_unitOfWork = unitOfWork;
            m_repository = repository;            
        }

        #endregion Constructors

        #region Interface Methods

        /// <summary>
        /// Commits the changes to the database.
        /// </summary>
        public void Commit()
        {
            m_unitOfWork.Commit();
        }

        /// <summary>
        /// Counts quantity of entities.
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return m_repository.Count();
        }

        /// <summary>
        /// Finds all the entities with the given filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return m_repository.FindAll(filter);
        }

        /// <summary>
        /// Finds all the entities with the given filter.
        /// </summary>
        /// <param name="offset">How many entities to skip</param>
        /// <param name="limit">Limit the max number of entities to return</param>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order of the return</param>
        /// <returns></returns>
        public IEnumerable<TEntity> FindAll(int offset, int limit, Expression<Func<TEntity, bool>> filter, Expression<Func<IEnumerable<TEntity>, IEnumerable<TEntity>>> order)
        {
            return m_repository.FindAll(offset, limit, filter, order);
        }

        /// <summary>
        /// Get an entity by id.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        /// <returns>
        /// Return an entity, or null case the entity does not exists.
        /// </returns>
        public TEntity GetById(object id)
        {
            ExceptionHelper.ThrowIfNull("id", id);

            return m_repository.GetById(id);
        }

        /// <summary>
        /// Saves the entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void SaveEntities(IEnumerable<TEntity> entities)
        {
            ExceptionHelper.ThrowIfNull("entities", entities);

            foreach (var entity in entities)
            {
                SaveEntity(entity);
            }
        }

        /// <summary>
        /// Saves the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void SaveEntity(TEntity entity)
        {
            ExceptionHelper.ThrowIfNull("entity", entity);

            AssertSpecifications(entity, GetSaveSpecifications(entity));

            if (entity.IsNew)
            {
                m_repository.Add(entity);
            }
            else
            {
                m_repository.Edit(entity);
            }
        }

        /// <summary>
        /// Removes the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void RemoveEntity(object id)
        {
            ExceptionHelper.ThrowIfNull("id", id);
            var entity = m_repository.GetById(id);

            AssertSpecifications(entity, GetRemoveSpecifications(entity));

            m_repository.Delete(entity);
        }

        #endregion Interface Methods

        #region Specifications Protected Methods

        /// <summary>
        /// Gets the save specifications.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        protected virtual ISpecification<TEntity>[] GetSaveSpecifications(TEntity entity)
        {
            return new ISpecification<TEntity>[]
            {
                new MustComplyWithMetadataSpecificationBase<TEntity>()
            };
        }

        /// <summary>
        /// Gets the remove specifications.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        protected virtual ISpecification<TEntity>[] GetRemoveSpecifications(TEntity entity)
        {
            return new ISpecification<TEntity>[]
            {
                new MustNotBeNullSpecification<TEntity>()
            };
        }

        #endregion Specifications Protected Methods

        #region Helpers Methods

        /// <summary>
        /// Asserts the specifications.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="specifications">The specifications.</param>
        protected void AssertSpecifications(TEntity entity, ISpecification<TEntity>[] specifications)
        {
            SpecService.Assert(entity, specifications);
        }

        /// <summary>
        /// Asserts the specification.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="specification">The specification.</param>
        protected void AssertSpecification(TEntity entity, ISpecification<TEntity> specification)
        {
            SpecService.Assert(entity, specification);
        }

        #endregion Helpers Methods
    }
}