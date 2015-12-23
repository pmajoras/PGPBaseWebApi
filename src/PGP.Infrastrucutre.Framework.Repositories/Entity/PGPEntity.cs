using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Id
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
