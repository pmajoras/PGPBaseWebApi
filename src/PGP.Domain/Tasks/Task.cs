using System;
using System.ComponentModel.DataAnnotations;

namespace PGP.Domain.Tasks
{
    /// <summary>
    ///
    /// </summary>
    public class Task : EntityBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the task name.
        /// </summary>
        /// <value>
        /// The task name.
        /// </value>
        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        #endregion Public Properties
    }
}