using PGP.Domain.DomainHelpers;
using PGP.Infrastructure.Framework.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Domain.Boards.Specs
{
    public class BoardMustHaveOwnerSpec : DomainSpecification<Board>
    {
        public override bool IsSatisfiedBy(Board target)
        {
            if (target.Owner == null)
            {
                SpecificationResult.AddError(
                    (int)DomainErrors.BoardDoesNotHaveOwner,
                    DomainMessageHelper.MessageHandler.GetMessageFromEnum(DomainErrors.BoardDoesNotHaveOwner));
            }

            return !SpecificationResult.HasError;
        }
    }
}
