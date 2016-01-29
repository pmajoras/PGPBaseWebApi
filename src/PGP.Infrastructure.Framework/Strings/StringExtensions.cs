using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Framework.Strings
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether this instance is base64.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static bool IsBase64(this string str)
        {
            return Regex.Match(str,
                "^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$",
                RegexOptions.Compiled)
                .Success;
        }
    }
}
