using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Framework.Constants
{
    /// <summary>
    /// Class that contains a set of regex constants
    /// </summary>
    public static class RegexConstants
    {
        /// <summary>
        /// Allow only numbers and letters.
        /// </summary>
        public const string OnlyNumbersAndLetters = @"^\w+$";
    }
}
