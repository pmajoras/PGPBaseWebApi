using KissSpecifications;
using PGP.Domain.Tasks.Specs;
using PGP.Infrastructure.Framework.Repositories;
using System.Linq;

namespace PGP.Domain.Tasks
{
    /// <summary>
    /// The domain service for the <see cref="Task"/> Entity
    /// </summary>
    public class TaskService : DomainServiceBase<Task, ITaskRepository>, ITaskService
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

        protected override ISpecification<Task>[] GetSaveSpecifications(Task entity)
        {
            var specifications = base.GetSaveSpecifications(entity).ToList();
            specifications.AddRange(new ISpecification<Task>[]
            {
                new TaskHasTaskListSpec(),
                new TaskHasCreatedByUserSpec()
            });

            return specifications.ToArray();
        }
    }
}