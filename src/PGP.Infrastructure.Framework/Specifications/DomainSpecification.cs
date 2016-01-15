using PGP.Infrastructure.Framework.Specifications.Results;

namespace PGP.Infrastructure.Framework.Specifications
{
    /// <summary>
    /// The class that represents a Domain Specification of an entity
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    public abstract class DomainSpecification<TTarget> : IDomainSpecification<TTarget>
    {
        #region Constructors

        public DomainSpecification()
        {
            SpecificationResult = new DomainSpecificationResult();
        }

        #endregion Constructors

        #region Interface Methods And Properties

        /// <summary>
        /// Gets or sets the not satisfied reason.
        /// </summary>
        /// <value>
        /// The not satisfied reason.
        /// </value>
        public string NotSatisfiedReason
        {
            get; protected set;
        }

        /// <summary>
        /// Gets or sets the specification result.
        /// </summary>
        /// <value>
        /// The specification result.
        /// </value>
        public DomainSpecificationResult SpecificationResult { get; protected set; }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified target].
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public virtual bool IsSatisfiedBy(TTarget target)
        {
            return !SpecificationResult.HasError;
        }

        #endregion Interface Methods And Properties
    }
}