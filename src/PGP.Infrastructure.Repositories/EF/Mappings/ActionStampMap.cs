using System.Data.Entity.ModelConfiguration;
using PGP.Domain;

namespace PGP.Infrastructure.Repositories.EF.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    public class ActionStampMap : ComplexTypeConfiguration<ActionStamp>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionStampMap"/> class.
        /// </summary>
        public ActionStampMap()
        {
            Property(t => t.CreationDate)
                .HasColumnName("CreationDate")
                .IsRequired();
        }
    }
}
