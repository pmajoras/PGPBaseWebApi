using System.Collections.Generic;
using System.Linq;
using KissSpecifications;

namespace PGP.Infrastructure.Framework.Specifications.Errors
{
    /// <summary>
    /// A DomainSpecification Not Satisfied Exception class.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    public class DomainSpecificationNotSatisfiedException<TTarget> : SpecificationNotSatisfiedException
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainSpecificationNotSatisfiedException{TTarget}"/> class.
        /// </summary>
        /// <param name="notSatisfiedReason">The not satisfied reason.</param>
        /// <param name="notSatisfiedSpecifications">The specifications that were not satisfied.</param>
        public DomainSpecificationNotSatisfiedException(string notSatisfiedReason, ISpecification<TTarget>[] notSatisfiedSpecifications)
            : base(notSatisfiedReason)
        {
            if (notSatisfiedSpecifications != null && notSatisfiedSpecifications.Any())
            {
                var domainSpecifications = notSatisfiedSpecifications
                    .Where(x => x is IDomainSpecification<TTarget>)
                    .OfType<IDomainSpecification<TTarget>>();

                if (domainSpecifications.Any())
                {
                    var errorList = new List<DomainSpecificationError>();

                    foreach (var specification in domainSpecifications)
                    {
                        errorList.AddRange(specification.SpecificationResult.GetErrors());
                    }

                    Errors = errorList.ToArray();
                }
            }
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public DomainSpecificationError[] Errors { get; protected set; }

        #endregion Public Properties
    }
}