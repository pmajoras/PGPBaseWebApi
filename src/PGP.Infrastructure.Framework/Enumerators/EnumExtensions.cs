using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Framework.Enumerators
{
    /// <summary>
    /// A set of enum extensions
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Retrieve the description on the enum, e.g.
        /// [Description("Bright Pink")]
        /// BrightPink = 2,
        /// Then when you pass in the enum, it will retrieve the description
        /// </summary>
        /// <param name="enum">The Enumeration</param>
        /// <returns>A string representing the friendly name</returns>
        public static string GetEnumDescription(this Enum enumerator)
        {
            Type type = enumerator.GetType();

            MemberInfo[] memberInfo = type.GetMember(enumerator.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }

            return enumerator.ToString();
        }

        /// <summary>
        /// To the int.
        /// </summary>
        /// <param name="enumerator">The enumerator.</param>
        /// <returns></returns>
        public static int ToInt(this Enum enumerator)
        {
            return (int)Convert.ChangeType(enumerator, Enum.GetUnderlyingType(enumerator.GetType()));
        }
    }

}
