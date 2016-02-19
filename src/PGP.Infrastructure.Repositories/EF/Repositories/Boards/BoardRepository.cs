using PGP.Domain.Boards;
using PGP.Infrastructure.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Repositories.EF.Repositories.Boards
{
    /// <summary>
    /// 
    /// </summary>
    public class BoardRepository : EFGenericRepository<Board>, IBoardRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoardRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public BoardRepository(IDomainContext context)
            : base(context)
        {

        }
    }
}
