using PGP.Infrastructure.Framework.Messages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PGP.Infrastructure.Framework.WebApi.Models.Responses
{
    /// <summary>
    /// The class that is tha base response of the API
    /// </summary>
    public class ApiResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        public ApiResponse()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <exception cref="System.ArgumentNullException">content;The content of the response cannot be null.</exception>
        public ApiResponse(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content", "The content of the response cannot be null.");
            }
            Content = content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <exception cref="System.ArgumentNullException">content;The content of the response cannot be null.</exception>
        public ApiResponse(IViewModel content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content", "The content of the response cannot be null.");
            }
            Content = content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="error">The error.</param>
        /// <exception cref="System.ArgumentNullException">error;The argument error cannot be null.</exception>
        public ApiResponse(ErrorContent error)
        {
            if (error == null)
            {
                throw new ArgumentNullException("error", "The argument error cannot be null.");
            }

            Errors = new List<ErrorContent>() { error }.ToArray();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        /// <exception cref="System.ArgumentNullException">errors;The argument error cannot be null.</exception>
        public ApiResponse(IEnumerable<ErrorContent> errors)
        {
            if (errors == null)
            {
                throw new ArgumentNullException("errors", "The argument error cannot be null.");
            }

            Errors = errors.ToArray();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse"/> class.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="errors">The errors.</param>
        public ApiResponse(IViewModel content, ErrorContent[] errors)
            : this(content)
        {
            Errors = errors;
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the content of the response
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public object Content { get; set; }

        /// <summary>
        /// Gets or sets the errors of the response.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public ErrorContent[] Errors { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="ApiResponse"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success
        {
            get
            {
                return Errors == null || Errors.Length == 0;
            }
        }

        #endregion Public Properties
    }
}