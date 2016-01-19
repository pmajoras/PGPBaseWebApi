namespace PGP.Infrastructure.Framework.Repositories
{
    /// <summary>
    /// The Entity Base Class
    /// </summary>
    public class PGPEntity : IEntity
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public long Id
        {
            get; set;
        }

        /// <summary>
        /// Gets a value indicating whether this instance is a new entity.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is new; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsNew
        {
            get { return Id == 0; }
        }
    }
}