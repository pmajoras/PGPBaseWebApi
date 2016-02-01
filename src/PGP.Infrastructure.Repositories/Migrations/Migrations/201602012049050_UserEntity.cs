namespace PGP.Infrastructure.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 200),
                        NickName = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false, maxLength: 4000),
                        Salt = c.String(nullable: false, maxLength: 4000),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true, name: "UN_Username");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", "UN_Username");
            DropTable("dbo.Users");
        }
    }
}
