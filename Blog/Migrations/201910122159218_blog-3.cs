namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blog3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Describtion", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "Describtion", c => c.String(nullable: false, maxLength: 500));
        }
    }
}
