using System;
using System.Collections.Generic;
using System.Linq;
using KissSpecifications;

namespace PGP.Infrastructure.Framework.Specifications.Errors
{
    /// <summary>
    /// A DomainSpecification Not Satisfied Exception class.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    public class DomainSpecificationNotSatisfiedException<TTarget> : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainSpecificationNotSatisfiedException{TTarget}"/> class.
        /// </summary>
        /// <param name="notSatisfiedReason">The not satisfied reason.</param>
        /// <param name="notSatisfiedSpecifications">The specifications that were not satisfied.</param>
        public DomainSpecificationNotSatisfiedException(ISpecification<TTarget>[] notSatisfiedSpecifications)
        {
            var errorList = new List<DomainSpecificationError>();

            if (notSatisfiedSpecifications != null && notSatisfiedSpecifications.Any())
            {


                foreach (ISpecification<TTarget> specification in notSatisfiedSpecifications)
                {
                    if (specification is IDomainSpecification<TTarget>)
                    {
                        errorList.AddRange(((IDomainSpecification<TTarget>)specification)
                            .SpecificationResult.GetErrors());
                    }
                    else
                    {
                        errorList.Add(new DomainSpecificationError(specification.NotSatisfiedReason));
                    }
                }
            }

            Errors = errorList.ToArray();
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

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Errors.Select(x => x.NotSatisfiedReason));
        }
    }
}