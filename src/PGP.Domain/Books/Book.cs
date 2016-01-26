using System;
using System.ComponentModel.DataAnnotations;

namespace PGP.Domain.Books
{
    /// <summary>
    ///
    /// </summary>
    public class Book : EntityBase
    {
        #region Public Properties

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        #endregion Public Properties
    }
}