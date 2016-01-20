using System;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq.Expressions;
using PGP.Infrastructure.Framework.PropertyHelpers;

namespace PGP.Infrastructure.Repositories.EF.Mappings
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class BaseEntityTypeConfiguration<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : class
    {
        #region MapMetadata Methods

        /// <summary>
        /// Maps the metadata.
        /// </summary>
        /// <param name="mapExpression">The map expression.</param>
        public StringPropertyConfiguration MapMetadata(Expression<Func<TEntity, string>> mapExpression)
        {
            var memberToMap = PropertyHelper.GetMemberInfo(mapExpression);

            var stringPropertyConfiguration = Property(mapExpression);
            if (memberToMap.IsMemberRequired())
            {
                stringPropertyConfiguration.IsRequired();
            }

            if (memberToMap.HasMaxLength())
            {
                stringPropertyConfiguration.HasMaxLength(memberToMap.GetMemberMaxLength());
            }

            return stringPropertyConfiguration;
        }

        /// <summary>
        /// Maps the metadata.
        /// </summary>
        /// <typeparam name="TPropertyType">The type of the property type.</typeparam>
        /// <param name="mapExpression">The map expression.</param>
        public PrimitivePropertyConfiguration MapMetadata<TPropertyType>(Expression<Func<TEntity, TPropertyType>> mapExpression)
            where TPropertyType : struct
        {
            var memberToMap = PropertyHelper.GetMemberInfo(mapExpression);

            var propertyConfiguration = Property(mapExpression);

            if (memberToMap.IsMemberRequired())
            {
                propertyConfiguration.IsRequired();
            }

            return propertyConfiguration;
        }

        #endregion MapMetadata Methods
    }
}