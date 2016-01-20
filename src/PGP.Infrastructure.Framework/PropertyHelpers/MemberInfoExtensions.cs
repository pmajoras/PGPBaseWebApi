using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace PGP.Infrastructure.Framework.PropertyHelpers
{
    /// <summary>
    ///
    /// </summary>
    public static class MemberInfoExtensions
    {
        /// <summary>
        /// Determines whether [is member required].
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static bool IsMemberRequired(this MemberInfo member)
        {
            return member.GetCustomAttributes(typeof(RequiredAttribute), true).Any();
        }

        /// <summary>
        /// Determines whether [has maximum length].
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns></returns>
        public static bool HasMaxLength(this MemberInfo member)
        {
            return member.GetMemberMaxLength() > -1;
        }

        /// <summary>
        /// Gets the maximum length of the member.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>returns -1 when member does not have a maximum length</returns>
        public static int GetMemberMaxLength(this MemberInfo member)
        {
            var maxLengthAttribute = member.GetCustomAttributes(typeof(MaxLengthAttribute)).FirstOrDefault()
                as MaxLengthAttribute;
            var stringLengthAttribute = member.GetCustomAttributes(typeof(StringLengthAttribute)).FirstOrDefault()
                as StringLengthAttribute;

            int maxLength = -1;

            if (maxLengthAttribute != null)
            {
                maxLength = maxLengthAttribute.Length;
            }
            else if (stringLengthAttribute != null && stringLengthAttribute.MaximumLength > 0)
            {
                maxLength = stringLengthAttribute.MaximumLength;
            }

            return maxLength;
        }
    }
}