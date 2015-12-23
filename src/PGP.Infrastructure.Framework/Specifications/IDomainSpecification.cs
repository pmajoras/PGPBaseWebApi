using KissSpecifications;
using PGP.Infrastructure.Framework.Specifications.Results;

namespace PGP.Infrastructure.Framework.Specifications
{
    /// <summary>
    /// An interface that represents a Domain Specification
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    public interface IDomainSpecification<TTarget> : ISpecification<TTarget>
    {
        /// <summary>
        /// Gets the specification result.
        /// </summary>
        /// <value>
        /// The specification result.
        /// </value>
        DomainSpecificationResult SpecificationResult { get; }
    }
}
