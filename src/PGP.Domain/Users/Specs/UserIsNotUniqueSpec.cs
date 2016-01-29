using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HelperSharp;
using PGP.Domain.DomainHelpers;
using PGP.Infrastructure.Framework.Specifications;

namespace PGP.Domain.Users.Specs
{
    public class UserIsNotUniqueSpec : DomainSpecification<User>
    {
        private IEnumerable<User> m_usersToCheck;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserIsNotUniqueSpec"/> class.
        /// </summary>
        /// <param name="usersToCheck">The users to check.</param>
        public UserIsNotUniqueSpec(IEnumerable<User> usersToCheck)
        {
            ExceptionHelper.ThrowIfNull("usersToCheck", usersToCheck);

            m_usersToCheck = usersToCheck;
        }

        /// <summary>
        /// Determines whether [is satisfied by] [the specified target].
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public override bool IsSatisfiedBy(User target)
        {
            if (m_usersToCheck.Count(x => x.Username == target.Username) > 0)
            {
                SpecificationResult.AddError(
                   (int)DomainErrors.UserUsernameAlreadyExists,
                   DomainMessageHelper.MessageHandler.GetMessageFromEnum(DomainErrors.UserUsernameAlreadyExists));
            }

            return base.IsSatisfiedBy(target);
        }
    }
}
