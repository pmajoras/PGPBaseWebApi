using PGP.Infrastructure.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KissSpecifications;

namespace PGP.Domain.Boards
{
    /// <summary>
    /// 
    /// </summary>
    public class BoardService : DomainServiceBase<Board, IBoardRepository>, IBoardService
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BoardService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <param name="repository">The repository.</param>
        public BoardService(IUnitOfWork unitOfWork, IBoardRepository repository)
            : base(unitOfWork, repository)
        {

        }

        #endregion

        protected override ISpecification<Board>[] GetSaveSpecifications(Board entity)
        {
            var specifications = base.GetSaveSpecifications(entity).ToList();
            specifications.AddRange(new ISpecification<Board>[]
            {
            });

            return specifications.ToArray();
        }
    }
}
