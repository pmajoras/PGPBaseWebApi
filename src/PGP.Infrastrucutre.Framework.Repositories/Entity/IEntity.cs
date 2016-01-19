namespace PGP.Infrastructure.Framework.Repositories
{
    /// <summary>
    /// Interface that indicates that the object is an entity
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        long Id
        {
            get; set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is new.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </value>
        bool IsNew
        {
            get;
        }
    }
}