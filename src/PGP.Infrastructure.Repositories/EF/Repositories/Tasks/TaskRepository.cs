using PGP.Domain.Tasks;
using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Infrastructure.Repositories.EF.Repositories.Tasks
{
    /// <summary>
    ///
    /// </summary>
    public class TaskRepository : EFGenericRepository<Task>, ITaskRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public TaskRepository(IDomainContext context)
            : base(context)
        {
        }
    }
}