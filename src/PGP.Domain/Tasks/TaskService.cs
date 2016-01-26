using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Domain.Tasks
{
    /// <summary>
    /// The domain service for the <see cref="Task"/> Entity
    /// </summary>
    public class TaskService : DomainServiceBase<Task, ITaskRepository>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository.</param>
        public TaskService(IUnitOfWork unitOfWork, ITaskRepository repository)
            : base(unitOfWork, repository)
        {
        }
    }
}