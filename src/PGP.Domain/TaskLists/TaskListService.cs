using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Domain.TaskLists
{
    /// <summary>
    /// The domain service for the <see cref="Task"/> Entity
    /// </summary>
    public class TaskListService : DomainServiceBase<TaskList, ITaskListRepository>, ITaskListService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskListService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository.</param>
        public TaskListService(IUnitOfWork unitOfWork, ITaskListRepository repository)
            : base(unitOfWork, repository)
        {
        }
    }
}