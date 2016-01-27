namespace PGP.Infrastructure.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TaskListsMap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TaskLists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tasks", "Description", c => c.String(nullable: false, maxLength: 4000));
            AddColumn("dbo.Tasks", "TaskListId", c => c.Long(nullable: false));
            CreateIndex("dbo.Tasks", "TaskListId");
            AddForeignKey("dbo.Tasks", "TaskListId", "dbo.TaskLists", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskListId", "dbo.TaskLists");
            DropIndex("dbo.Tasks", new[] { "TaskListId" });
            DropColumn("dbo.Tasks", "TaskListId");
            DropColumn("dbo.Tasks", "Description");
            DropTable("dbo.TaskLists");
        }
    }
}
