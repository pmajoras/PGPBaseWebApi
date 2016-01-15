namespace PGP.Infrastructure.Framework.WebApi.Models
{
    /// <summary>
    ///
    /// </summary>
    public class ErrorContent
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorContent"/> class.
        /// </summary>
        public ErrorContent()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorContent"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public ErrorContent(string message)
        {
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorContent"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="code">The code.</param>
        public ErrorContent(string message, int code)
        {
            Message = message;
            Code = code;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorContent"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="code">The code.</param>
        /// <param name="fieldName">Name of the field.</param>
        public ErrorContent(string message, int code, string fieldName)
            : this(message, code)
        {
            FieldName = fieldName;
        }

        #endregion Constructors

        #region Public Properties

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public int? Code { get; set; }

        /// <summary>
        /// Gets or sets the name of the field.
        /// </summary>
        /// <value>
        /// The name of the field.
        /// </value>
        public string FieldName { get; set; }

        #endregion Public Properties
    }
}