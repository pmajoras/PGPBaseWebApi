using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Repositories.EF.Mappings
{
    public static class PropertyConfigurationExtensions
    {
        /// <summary>
        /// Determines whether [has unique index] [the specified index name].
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="indexName">Name of the index.</param>
        /// <returns></returns>
        public static PrimitivePropertyConfiguration HasUniqueIndex(this PrimitivePropertyConfiguration property, string indexName = null)
        {
            return property.HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute(indexName)
                        {
                            IsUnique = true
                        }));
        }
    }
}
