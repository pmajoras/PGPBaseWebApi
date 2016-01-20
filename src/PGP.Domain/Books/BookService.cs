using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGP.Infrastructure.Framework.Repositories;

namespace PGP.Domain.Books
{
    /// <summary>
    /// The domain service for the <see cref="Book"/> Entity
    /// </summary>
    public class BookService : DomainServiceBase<Book, IBookRepository>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository.</param>
        public BookService(IUnitOfWork unitOfWork, IBookRepository repository)
            : base(unitOfWork, repository)
        {
        }
    }
}
