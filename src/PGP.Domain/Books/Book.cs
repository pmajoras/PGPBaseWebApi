using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGP.Infrastructure.Framework.Repositories;

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

        #endregion
    }
}
