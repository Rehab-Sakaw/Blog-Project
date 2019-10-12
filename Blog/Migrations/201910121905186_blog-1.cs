namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blog1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Describtion = c.String(nullable: false, maxLength: 1000),
                        PostTime = c.DateTime(nullable: false),
                        UserID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Describtion = c.String(nullable: false, maxLength: 500),
                        UserID = c.Int(nullable: false),
                        PostID = c.Int(nullable: false),
                        CommentTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserID, cascadeDelete: false)
                .Index(t => t.UserID)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Role = c.String(),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "UserID", "dbo.Users");
            DropForeignKey("dbo.Comments", "PostID", "dbo.Posts");
            DropForeignKey("dbo.Posts", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Comments", new[] { "PostID" });
            DropIndex("dbo.Comments", new[] { "UserID" });
            DropIndex("dbo.Posts", new[] { "CategoryID" });
            DropIndex("dbo.Posts", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
