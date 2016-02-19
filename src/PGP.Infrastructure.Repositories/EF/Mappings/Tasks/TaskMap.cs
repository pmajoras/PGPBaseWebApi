using PGP.Domain.Tasks;

namespace PGP.Infrastructure.Repositories.EF.Mappings.Tasks
{
    /// <summary>
    ///
    /// </summary>
    public class TaskMap : BaseEntityTypeConfiguration<Task>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskMap"/> class.
        /// </summary>
        public TaskMap()
        {
            ToTable("Tasks");

            HasKey(x => x.Id);
            MapMetadata(x => x.Name);
            HasRequired(x => x.CreatedByUser)
                .WithMany()
                .HasForeignKey(x => x.CreatedByUserId)
                .WillCascadeOnDelete(false);
        }
    }
}