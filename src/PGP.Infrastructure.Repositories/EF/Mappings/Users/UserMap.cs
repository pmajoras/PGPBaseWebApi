using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGP.Domain.Users;

namespace PGP.Infrastructure.Repositories.EF.Mappings.Users
{
    /// <summary>
    /// 
    /// </summary>
    public class UserMap : BaseEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserMap"/> class.
        /// </summary>
        public UserMap()
        {
            ToTable("Users");

            HasKey(x => x.Id);
            MapMetadata(x => x.FullName);
            MapMetadata(x => x.NickName);

            MapMetadata(x => x.Username)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName,
                    new IndexAnnotation(
                        new IndexAttribute("UN_Username", 1)
                        {
                            IsUnique = true
                        }));

            MapMetadata(x => x.Password);
            MapMetadata(x => x.Salt);
        }
    }
}
