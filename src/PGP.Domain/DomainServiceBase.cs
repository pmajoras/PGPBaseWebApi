using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Domain
{
    /// <summary>
    /// The base domain service.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TRepository">The type of the repository.</typeparam>
    public abstract class DomainServiceBase<TEntity, TRepository> : PGPDomainService<TEntity>
        where TEntity : IEntity
        where TRepository : IRepository<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainServiceBase{TEntity, TRepository}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository.</param>
        public DomainServiceBase(IUnitOfWork unitOfWork, TRepository repository)
            : base(unitOfWork, repository)
        {
        }
    }
}