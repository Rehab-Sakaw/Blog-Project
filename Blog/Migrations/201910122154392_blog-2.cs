namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blog2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Describtion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Describtion", c => c.String(nullable: false, maxLength: 1000));
            AlterColumn("dbo.Posts", "Title", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
