using PGP.Domain.DomainHelpers;
using PGP.Infrastructure.Framework.Specifications;
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
    public class TaskHasCreatedByUserSpec : DomainSpecification<Task>
    {

        /// <summary>
        /// Determines whether [is satisfied by] [the specified target].
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public override bool IsSatisfiedBy(Task target)
        {
            if (target.CreatedByUser == null)
            {

                SpecificationResult.AddError(
                    (int)DomainErrors.TaskDoesNotHaveUser,
                    DomainMessageHelper.MessageHandler.GetMessageFromEnum(DomainErrors.TaskDoesNotHaveUser));
            }

            return !SpecificationResult.HasError;
        }
    }
}
