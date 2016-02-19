using PGP.Domain.Boards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Repositories.EF.Mappings.Boards
{
    public class BoardMap : BaseEntityTypeConfiguration<Board>
    {
        public BoardMap()
        {
            ToTable("Boards");

            HasKey(x => x.Id);
            MapMetadata(x => x.Name);
            MapMetadata(x => x.Description);

            HasRequired(x => x.Owner)
                .WithMany()
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.TaskLists)
                .WithRequired(x => x.Board)
                .HasForeignKey(x => x.BoardId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Users)
                .WithMany()
                .Map(x =>
                {
                    x.MapLeftKey("BoardId");
                    x.MapRightKey("UserId");
                    x.ToTable("BoardsToUsers");
                });
        }
    }
}
