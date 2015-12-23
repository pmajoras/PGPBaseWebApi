using HelperSharp;
using System;
using System.Linq.Expressions;

namespace PGP.Infrastructure.Framework.PropertyHelpers
{
    /// <summary>
    /// A static class that contains helper methods for properties.
    /// </summary>
    public static class PropertyHelper
    {

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyLambda">The property lambda.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">You must pass a lambda of the form: '() => Class.Property' or '() => object.Property' or 'x=> x.Property'</exception>
        public static string GetPropertyName<T>(Expression<Func<T, object>> propertyLambda)
        {
            ExceptionHelper.ThrowIfNull("propertyLambda", propertyLambda);

            MemberExpression me = propertyLambda.Body as MemberExpression;
            if (me == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property' or 'x=> x.Property'");
            }

            string result = string.Empty;
            do
            {
                result = me.Member.Name + "." + result;
                me = me.Expression as MemberExpression;
            } while (me != null);

            result = result.Remove(result.Length - 1); // remove the trailing "."
            return result;
        }
    }
}
