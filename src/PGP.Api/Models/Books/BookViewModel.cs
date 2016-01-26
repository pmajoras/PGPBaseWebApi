using PGP.Domain.Books;
using PGP.Infrastructure.Framework.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PGP.Api.Models.Books
{
    public class BookViewModel : IViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookViewModel"/> class.
        /// </summary>
        public BookViewModel(Book book)
        {
            Name = book.Name;
            ReleaseDate = book.ReleaseDate;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the release date.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        public DateTime ReleaseDate { get; set; }
    }
}