using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PGP.Infrastructure.Framework.Globalization
{
    /// <summary>
    /// Utilities for currency questions.
    /// </summary>
    public static class CultureInfoHelper
    {
        #region Fields

        private static Dictionary<string, CultureInfo> s_cultureInfoCache = new Dictionary<string, CultureInfo>();

        #endregion Fields

        #region Methods

        /// <summary>
        /// Get the currency info througt the symbol of a cash.
        /// </summary>
        /// <param name="isoCurrencySymbol">The currency symbol in ISO pattern. <example>BRL e USD.</example></param>
        /// <returns>A cultura.</returns>
        public static CultureInfo GetCultureInfoByCurrency(string isoCurrencySymbol)
        {
            lock (s_cultureInfoCache)
            {
                if (!s_cultureInfoCache.ContainsKey(isoCurrencySymbol))
                {
                    var cultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                        .OrderBy(query => query.ToString().Length)
                        .FirstOrDefault(c => new RegionInfo(c.LCID).ISOCurrencySymbol.Equals(isoCurrencySymbol, StringComparison.OrdinalIgnoreCase));

                    s_cultureInfoCache.Add(isoCurrencySymbol, cultureInfo);
                }

                return s_cultureInfoCache[isoCurrencySymbol];
            }
        }

        #endregion Methods
    }
}