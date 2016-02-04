using System.Linq;
using KissSpecifications;
using PGP.Infrastructure.Framework.Specifications.Errors;

namespace PGP.Infrastructure.Framework.Specifications
{
    /// <summary>
    ///
    /// </summary>
    public static class SpecService
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="SpecService"/> class.
        /// </summary>
        static SpecService()
        {
        }

        #endregion Constructors

        /// <summary>
        /// Asserts the specified target.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="specifications">The specifications.</param>
        public static void Assert<TTarget>(TTarget target, params ISpecification<TTarget>[] specifications)
        {
            var notSatisfiedSpecifications = SpecificationService.FilterSpecificationsAreNotSatisfiedBy(target, specifications);

            if (notSatisfiedSpecifications != null && notSatisfiedSpecifications.Any())
            {
                throw new DomainSpecificationNotSatisfiedException()
                    .SetNotSatisfiedSpecificationsErrors(notSatisfiedSpecifications);
            }
        }

        /// <summary>
        /// Asserts the groups.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="target">The target.</param>
        /// <param name="groupKeys">The group keys.</param>
        public static void AssertGroups<TTarget>(TTarget target, params object[] groupKeys)
        {
            var notSatisfiedSpecifications = SpecificationService.FilterSpecificationsAreNotSatisfiedBy(target, groupKeys);
            if (notSatisfiedSpecifications != null && notSatisfiedSpecifications.Any())
            {
                throw new DomainSpecificationNotSatisfiedException()
                    .SetNotSatisfiedSpecificationsErrors(notSatisfiedSpecifications);
            }
        }
    }
}