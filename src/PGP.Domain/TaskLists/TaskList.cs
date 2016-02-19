using PGP.Domain.Boards;
using PGP.Domain.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGP.Domain.TaskLists
{
    /// <summary>
    ///
    /// </summary>
    public class TaskList : EntityBase
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the task list name.
        /// </summary>
        /// <value>
        /// The task list name.
        /// </value>
        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the tasks of this task list.
        /// </summary>
        /// <value>
        /// The tasks in this task list.
        /// </value>
        public IList<Task> Tasks { get; set; }

        /// <summary>
        /// Gets or sets the board.
        /// </summary>
        /// <value>
        /// The board.
        /// </value>
        public Board Board { get; set; }

        /// <summary>
        /// Gets or sets the board identifier.
        /// </summary>
        /// <value>
        /// The board identifier.
        /// </value>
        public long BoardId { get; set; }

        #endregion Public Properties
    }
}