using System;
using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Domain
{
    /// <summary>
    ///
    /// </summary>
    public class EntityBase : PGPEntity
    {
        /// <summary>
        /// Gets or sets the stamp.
        /// </summary>
        /// <value>
        /// The stamp.
        /// </value>
        public ActionStamp Stamp { get; set; }
    }
}