using PGP.Domain.TaskLists;
using PGP.Infrastructure.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Repositories.EF.Repositories.TaskLists
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskListRepository : EFGenericRepository<TaskList>, ITaskListRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskListRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TaskListRepository(IDomainContext context)
            : base(context)
        {

        }
    }
}
