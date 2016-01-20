using System;
using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Infrastructure.Repositories.EF
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class EFGenericRepository<TEntity> : PGPRepository<TEntity>
        where TEntity : class, IEntity
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EFGenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EFGenericRepository(IDomainContext context)
            : base(context)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EFGenericRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="func">The function.</param>
        public EFGenericRepository(Func<IDomainContext> func)
            : base(func.Invoke())
        {
        }

        #endregion Constructors

        /// <summary>
        /// Befores the delete new item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void BeforeDeleteItem(TEntity entity)
        {
            base.BeforeDeleteItem(entity);
        }

        /// <summary>
        /// Befores the persist new item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void BeforePersistNewItem(TEntity entity)
        {
            base.BeforePersistNewItem(entity);
        }

        /// <summary>
        /// Befores the persist updated item.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void BeforePersistUpdatedItem(TEntity entity)
        {
            base.BeforePersistUpdatedItem(entity);
        }
    }
}