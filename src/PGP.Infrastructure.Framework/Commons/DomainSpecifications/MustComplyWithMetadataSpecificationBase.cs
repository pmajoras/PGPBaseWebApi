using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HelperSharp;
using PGP.Infrastructure.Framework.Specifications;
using PGP.Infrastructure.Framework.Specifications.Errors;

namespace PGP.Infrastructure.Framework.Commons.DomainSpecifications
{
    /// <summary>
    /// Must comply with metadata specification.
    /// </summary>
	public class MustComplyWithMetadataSpecificationBase<TTarget> : DomainSpecification<TTarget>
    {
        #region NotSatisfiedReasons

        protected Dictionary<Type, DomainSpecificationError> m_errorReasons = new Dictionary<Type, DomainSpecificationError>();

        #endregion NotSatisfiedReasons

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MustComplyWithMetadataSpecificationBase{TTarget}"/> class.
        /// </summary>
        public MustComplyWithMetadataSpecificationBase()
        {
            m_errorReasons.Add(typeof(RequiredAttribute), new DomainSpecificationError(0, "The field is required", string.Empty));
            m_errorReasons.Add(typeof(MinLengthAttribute), new DomainSpecificationError(1, "The field minimum length is", string.Empty));
            m_errorReasons.Add(typeof(MaxLengthAttribute), new DomainSpecificationError(2, "The field max length is", string.Empty));
        }

        public MustComplyWithMetadataSpecificationBase(int requiredErrorCode, int minLengthErrorCode, int maxLengthErrorCode)
        {
            m_errorReasons.Add(typeof(RequiredAttribute), new DomainSpecificationError(requiredErrorCode, "The field is required.", string.Empty));
            m_errorReasons.Add(typeof(MinLengthAttribute), new DomainSpecificationError(minLengthErrorCode, "The field minimum length is", string.Empty));
            m_errorReasons.Add(typeof(MaxLengthAttribute), new DomainSpecificationError(maxLengthErrorCode, "The field max length is", string.Empty));
        }

        public MustComplyWithMetadataSpecificationBase(Dictionary<Type, DomainSpecificationError> customErrors)
        {
            ExceptionHelper.ThrowIfNull("customErrors", customErrors);

            foreach (var error in customErrors)
            {
                if (!m_errorReasons.ContainsKey(error.Key))
                {
                    m_errorReasons.Add(error.Key, error.Value);
                }
            }
        }

        #endregion Constructors

        #region Interface Methods

        /// <summary>
        /// Determines whether the target object satisfies the specification.
        /// </summary>
        /// <param name="target">The target object to be validated.</param>
        /// <returns><c>true</c> if this instance is satisfied by the specified target; otherwise, <c>false</c>.</returns>
        public override bool IsSatisfiedBy(TTarget target)
        {
            var targetType = target.GetType();

            var propertiesToValidate = targetType.GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(ValidationAttribute), true).Any());

            foreach (var property in propertiesToValidate)
            {
                foreach (ValidationAttribute attributeToValidate in property.GetCustomAttributes(typeof(ValidationAttribute), true))
                {
                    var isValid = attributeToValidate.IsValid(property.GetValue(target));

                    if (!isValid)
                    {
                        SpecificationResult
                            .AddError(GetErrorFromInvalidAttribute(attributeToValidate, property.Name));
                    }
                }
            }

            return base.IsSatisfiedBy(target);
        }

        #endregion Interface Methods

        #region Protected Methods

        /// <summary>
        /// Gets the error from invalid attribute.
        /// </summary>
        /// <param name="attribute">The attribute.</param>
        /// <param name="fieldName">Name of the field.</param>
        /// <returns></returns>
        protected virtual DomainSpecificationError GetErrorFromInvalidAttribute(ValidationAttribute attribute, string fieldName)
        {
            string errorMessage = string.IsNullOrEmpty(attribute.ErrorMessage) ? null : attribute.ErrorMessage;

            var returnError = new DomainSpecificationError(-1, errorMessage, fieldName);
            DomainSpecificationError currentError = null;

            if (m_errorReasons.TryGetValue(attribute.GetType(), out currentError))
            {
                errorMessage = errorMessage ?? currentError.NotSatisfiedReason;
                returnError = new DomainSpecificationError(currentError.ErrorCode, errorMessage, fieldName);
            }

            return returnError;
        }

        #endregion Protected Methods
    }
}