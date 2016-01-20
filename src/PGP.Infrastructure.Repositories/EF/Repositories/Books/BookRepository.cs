using PGP.Domain.Books;
using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Infrastructure.Repositories.EF.Repositories.Books
{
    /// <summary>
    ///
    /// </summary>
    public class BookRepository : EFGenericRepository<Book>, IBookRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BookRepository(IDomainContext context)
            : base(context)
        {
        }
    }
}