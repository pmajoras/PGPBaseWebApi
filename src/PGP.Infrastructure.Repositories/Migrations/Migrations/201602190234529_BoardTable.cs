namespace PGP.Infrastructure.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoardTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "TaskListId", "dbo.TaskLists");
            DropIndex("dbo.Users", "UN_Username");
            CreateTable(
                "dbo.Boards",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 300),
                        Description = c.String(maxLength: 1000),
                        OwnerId = c.Long(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.BoardsToUsers",
                c => new
                    {
                        BoardId = c.Long(nullable: false),
                        UserId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.BoardId, t.UserId })
                .ForeignKey("dbo.Boards", t => t.BoardId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.BoardId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Tasks", "CreatedByUserId", c => c.Long(nullable: false));
            AddColumn("dbo.TaskLists", "BoardId", c => c.Long(nullable: false));
            CreateIndex("dbo.Users", "Username", unique: true, name: "UN_Username");
            CreateIndex("dbo.Tasks", "CreatedByUserId");
            CreateIndex("dbo.TaskLists", "BoardId");
            AddForeignKey("dbo.Tasks", "CreatedByUserId", "dbo.Users", "Id");
            AddForeignKey("dbo.TaskLists", "BoardId", "dbo.Boards", "Id");
            AddForeignKey("dbo.Tasks", "TaskListId", "dbo.TaskLists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "TaskListId", "dbo.TaskLists");
            DropForeignKey("dbo.BoardsToUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.BoardsToUsers", "BoardId", "dbo.Boards");
            DropForeignKey("dbo.TaskLists", "BoardId", "dbo.Boards");
            DropForeignKey("dbo.Boards", "OwnerId", "dbo.Users");
            DropForeignKey("dbo.Tasks", "CreatedByUserId", "dbo.Users");
            DropIndex("dbo.BoardsToUsers", new[] { "UserId" });
            DropIndex("dbo.BoardsToUsers", new[] { "BoardId" });
            DropIndex("dbo.Boards", new[] { "OwnerId" });
            DropIndex("dbo.TaskLists", new[] { "BoardId" });
            DropIndex("dbo.Tasks", new[] { "CreatedByUserId" });
            DropIndex("dbo.Users", "UN_Username");
            DropColumn("dbo.TaskLists", "BoardId");
            DropColumn("dbo.Tasks", "CreatedByUserId");
            DropTable("dbo.BoardsToUsers");
            DropTable("dbo.Boards");
            CreateIndex("dbo.Users", "Username", unique: true, name: "UN_Username");
            AddForeignKey("dbo.Tasks", "TaskListId", "dbo.TaskLists", "Id", cascadeDelete: true);
        }
    }
}
