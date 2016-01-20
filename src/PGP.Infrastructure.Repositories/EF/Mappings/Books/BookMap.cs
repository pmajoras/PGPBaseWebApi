using Escrutinador.Extensions.EntityFramework;
using PGP.Domain.Books;

namespace PGP.Infrastructure.Repositories.EF.Mappings.Books
{
    /// <summary>
    ///
    /// </summary>
    public class BookMap : MetadataEntityTypeConfiguration<Book>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookMap"/> class.
        /// </summary>
        public BookMap()
        {
            ToTable("Book");

            HasKey(x => x.Id);
            MapMetadata(x => x.Name);
            MapMetadata(x => x.ReleaseDate);
        }
    }
}