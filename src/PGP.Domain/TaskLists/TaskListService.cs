using KissSpecifications;
using PGP.Domain.TaskLists.Specs;
using PGP.Infrastructure.Framework.Repositories;
using System.Linq;

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

        protected override ISpecification<TaskList>[] GetSaveSpecifications(TaskList entity)
        {
            var specifications = base.GetSaveSpecifications(entity).ToList();
            specifications.AddRange(new ISpecification<TaskList>[]
            {
                new TaskListMustHaveBoardSpec()
            });

            return specifications.ToArray();
        }
    }
}