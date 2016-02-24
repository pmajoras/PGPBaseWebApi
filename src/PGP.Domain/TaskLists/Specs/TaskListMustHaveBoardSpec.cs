using PGP.Domain.DomainHelpers;
using PGP.Infrastructure.Framework.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.TaskLists.Specs
{

    public class TaskListMustHaveBoardSpec : DomainSpecification<TaskList>
    {
        /// <summary>
        /// Determines whether [is satisfied by] [the specified target].
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public override bool IsSatisfiedBy(TaskList target)
        {
            if (target.Board == null)
            {
                SpecificationResult.AddError(
                    (int)DomainErrors.TaskListDoesNothaveBoard,
                    DomainMessageHelper.MessageHandler.GetMessageFromEnum(DomainErrors.TaskListDoesNothaveBoard));
            }

            return !SpecificationResult.HasError;
        }
    }
}
