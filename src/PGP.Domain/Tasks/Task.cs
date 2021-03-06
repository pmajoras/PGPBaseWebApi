﻿using PGP.Domain.TaskLists;
using PGP.Domain.Users;
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

        /// <summary>
        /// Gets or sets the task description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Required]
        [StringLength(4000)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the task list.
        /// </summary>
        /// <value>
        /// The task list.
        /// </value>
        public TaskList TaskList { get; set; }

        /// <summary>
        /// Gets or sets the task list identifier.
        /// </summary>
        /// <value>
        /// The task list identifier.
        /// </value>
        public long TaskListId { get; set; }

        /// <summary>
        /// Gets or sets the created by user.
        /// </summary>
        /// <value>
        /// The created by user.
        /// </value>
        public User CreatedByUser { get; set; }

        /// <summary>
        /// Gets or sets the created by user identifier.
        /// </summary>
        /// <value>
        /// The created by user identifier.
        /// </value>
        public long CreatedByUserId { get; set; }

        #endregion Public Properties
    }
}