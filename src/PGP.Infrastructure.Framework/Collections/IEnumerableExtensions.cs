using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HelperSharp;
using PGP.Infrastructure.Framework.PropertyHelpers;

namespace PGP.Infrastructure.Framework.Collections
{
    /// <summary>
    /// Extension methods to IEnumerable.
    /// </summary>
    public static class IEnumerableExtensions
    {
        /// <summary>
        /// Executs a distinct operation by the specified property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="propertyToDistinctBy">The property to distinct by.</param>
        /// <returns></returns>
        public static IEnumerable<T> DistinctByProperty<T>(this IEnumerable<T> list, Expression<Func<T, object>> propertyToDistinctBy)
        {
            ExceptionHelper.ThrowIfNull("propertyToDistinctBy", propertyToDistinctBy);

            var propertyName = PropertyHelper.GetPropertyName(propertyToDistinctBy);
            var property = typeof(T).GetProperty(propertyName);
            var distinctList = new List<T>();

            foreach (var item in list)
            {
                if (!distinctList.Any(x => property.GetValue(item) == property.GetValue(x)))
                {
                    distinctList.Add(item);
                }
            }

            return distinctList;
        }
    }
}