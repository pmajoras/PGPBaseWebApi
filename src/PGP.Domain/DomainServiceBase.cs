using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using KissSpecifications;
using PGP.Domain.DomainHelpers;
using PGP.Infrastructure.Framework.Commons.DomainSpecifications;
using PGP.Infrastructure.Framework.Repositories;
using PGP.Infrastructure.Framework.Specifications.Errors;

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

        public override void SaveEntity(TEntity entity)
        {
            if (entity is EntityBase)
            {
                (entity as EntityBase).Stamp = new ActionStamp()
                {
                    CreationDate = DateTime.Now
                };
            }

            base.SaveEntity(entity);
        }

        protected override ISpecification<TEntity>[] GetSaveSpecifications(TEntity entity)
        {
            var mustComplyDictionary = new Dictionary<Type, DomainSpecificationError>();

            mustComplyDictionary.Add(typeof(RequiredAttribute),
                new DomainSpecificationError((int)DomainErrors.FieldIsRequired,
                    DomainMessageHelper.MessageHandler.GetMessageFromEnum(DomainErrors.FieldIsRequired)));

            mustComplyDictionary.Add(typeof(MinLengthAttribute),
                new DomainSpecificationError((int)DomainErrors.FieldHasMinLength,
                    DomainMessageHelper.MessageHandler.GetMessageFromEnum(DomainErrors.FieldHasMinLength)));

            mustComplyDictionary.Add(typeof(MaxLengthAttribute),
                new DomainSpecificationError((int)DomainErrors.FieldHasMaxLength,
                    DomainMessageHelper.MessageHandler.GetMessageFromEnum(DomainErrors.FieldHasMaxLength)));

            return new ISpecification<TEntity>[]
            {
                new MustComplyWithMetadataSpecificationBase<TEntity>(mustComplyDictionary)
            };
        }
    }
}