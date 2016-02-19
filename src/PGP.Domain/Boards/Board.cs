using PGP.Domain.TaskLists;
using PGP.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Boards
{
    public class Board : EntityBase
    {

        #region Public Properties

        /// <summary>
        /// Gets or sets the name of the board.
        /// </summary>
        /// <value>
        /// The name of the board.
        /// </value>
        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [StringLength(1000)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the owner.
        /// </summary>
        /// <value>
        /// The owner.
        /// </value>
        public User Owner { get; set; }

        /// <summary>
        /// Gets or sets the owner identifier.
        /// </summary>
        /// <value>
        /// The owner identifier.
        /// </value>
        public long OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public IList<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the task lists.
        /// </summary>
        /// <value>
        /// The task lists.
        /// </value>
        public IList<TaskList> TaskLists { get; set; }

        #endregion
    }
}
