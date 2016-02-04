using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using KissSpecifications;

namespace PGP.Infrastructure.Framework.Specifications.Errors
{
    /// <summary>
    /// A DomainSpecification Not Satisfied Exception class.
    /// </summary>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    [Serializable]
    public class DomainSpecificationNotSatisfiedException : Exception
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainSpecificationNotSatisfiedException"/> class.
        /// </summary>
        public DomainSpecificationNotSatisfiedException()
        {
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

        #region Public Methods

        /// <summary>
        /// Adds the specification errors.
        /// </summary>
        public DomainSpecificationNotSatisfiedException SetNotSatisfiedSpecificationsErrors<T>
            (ISpecification<T>[] notSatisfiedSpecifications)
        {
            var errorList = new List<DomainSpecificationError>();

            if (notSatisfiedSpecifications != null && notSatisfiedSpecifications.Any())
            {
                foreach (ISpecification<T> specification in notSatisfiedSpecifications)
                {
                    if (specification is IDomainSpecification<T>)
                    {
                        errorList.AddRange(((IDomainSpecification<T>)specification)
                            .SpecificationResult.GetErrors());
                    }
                    else
                    {
                        errorList.Add(new DomainSpecificationError(specification.NotSatisfiedReason));
                    }
                }
            }

            Errors = errorList.ToArray();
            return this;
        }


        #endregion

        public override string ToString()
        {
            return string.Join(Environment.NewLine, Errors.Select(x => x.NotSatisfiedReason));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}