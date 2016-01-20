using System;

namespace PGP.Domain.Books
{
    /// <summary>
    ///
    /// </summary>
    public class Book : EntityBase
    {
        #region Public Properties

        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        #endregion Public Properties
    }
}