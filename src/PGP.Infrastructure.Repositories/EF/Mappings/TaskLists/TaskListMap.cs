using PGP.Domain.TaskLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGP.Infrastructure.Repositories.EF.Mappings.TaskLists
{
    /// <summary>
    /// 
    /// </summary>
    public class TaskListMap : BaseEntityTypeConfiguration<TaskList>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TaskListMap"/> class.
        /// </summary>
        public TaskListMap()
        {
            ToTable("TaskLists");

            HasKey(x => x.Id);
            MapMetadata(x => x.Name);

            HasMany(x => x.Tasks)
                .WithRequired(x => x.TaskList)
                .HasForeignKey(x => x.TaskListId)
                .WillCascadeOnDelete(false);
        }
    }
}
