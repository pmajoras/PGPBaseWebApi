using System.Collections.Generic;
using System.Linq;
using HelperSharp;
using PGP.Infrastructure.Framework.Specifications.Errors;

namespace PGP.Infrastructure.Framework.Specifications.Results
{
    /// <summary>
    /// A Domain Specification Result Class
    /// </summary>
    public class DomainSpecificationResult
    {
        #region Private properties

        /// <summary>
        /// A list of errors
        /// </summary>
        private IList<DomainSpecificationError> m_errors;

        #endregion Private properties

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainSpecificationResult"/> class.
        /// </summary>
        public DomainSpecificationResult()
        {
            m_errors = new List<DomainSpecificationError>();
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether this instance has error.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has error; otherwise, <c>false</c>.
        /// </value>
        public bool HasError
        {
            get
            {
                return m_errors.Any();
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Gets the errors list.
        /// </summary>
        /// <returns></returns>
        public IList<DomainSpecificationError> GetErrors()
        {
            return m_errors.ToList();
        }

        /// <summary>
        /// Adds an error to the specification result.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="notSatisfiedReason">The not satisfied reason.</param>
        /// <param name="fieldName">Name of the field.</param>
        public void AddError(int errorCode, string notSatisfiedReason, string fieldName = null)
        {
            AddError(new DomainSpecificationError(errorCode, notSatisfiedReason, fieldName));
        }

        /// <summary>
        /// Adds an error to the specification result.
        /// </summary>
        /// <param name="error">The error.</param>
        public void AddError(DomainSpecificationError error)
        {
            ExceptionHelper.ThrowIfNull("error", error);

            if (!m_errors.Contains(error))
            {
                m_errors.Add(error);
            }
        }

        #endregion Public Methods
    }
}