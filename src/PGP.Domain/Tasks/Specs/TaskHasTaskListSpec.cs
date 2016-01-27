using PGP.Domain.DomainHelpers;
using PGP.Infrastructure.Framework.Specifications;
using PGP.Infrastructure.Framework.Specifications.Errors;
using PGP.Infrastructure.Framework.Specifications.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Tasks.Specs
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskHasTaskListSpec : DomainSpecification<Task>
    {

        /// <summary>
        /// Determines whether [is satisfied by] [the specified target].
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public override bool IsSatisfiedBy(Task target)
        {
            if (target.TaskList == null)
            {

                SpecificationResult.AddError(
                    (int)DomainErrors.TaskDoesNotHaveTaskList,
                    DomainMessageHelper.MessageHandler.GetMessageFromEnum(DomainErrors.TaskDoesNotHaveTaskList));
            }

            return !SpecificationResult.HasError;
        }
    }
}
