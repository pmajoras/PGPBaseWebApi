using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGP.Domain.DomainHelpers;
using PGP.Infrastructure.Framework.PropertyHelpers;
using PGP.Infrastructure.Framework.Specifications;

namespace PGP.Domain.Users.Specs
{
    public class UserHasValidPasswordSpec : DomainSpecification<User>
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UserHasValidPasswordSpec"/> class.
        /// </summary>
        public UserHasValidPasswordSpec()
        {

        }

        #endregion

        /// <summary>
        /// Determines whether [is satisfied by] [the specified target].
        /// </summary>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        public override bool IsSatisfiedBy(User target)
        {
            if (string.IsNullOrEmpty(target.Password) || target.Password.Length < 6)
            {
                SpecificationResult.AddError(
                    (int)DomainErrors.UserDoesNotHaveValidPassword,
                    DomainMessageHelper.MessageHandler.GetMessageFromEnum(DomainErrors.UserDoesNotHaveValidPassword),
                    "password");
            }

            return base.IsSatisfiedBy(target);
        }
    }
}
