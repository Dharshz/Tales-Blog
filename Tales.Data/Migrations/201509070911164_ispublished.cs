namespace Tales.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ispublished : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "IsPublished", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "IsPublished");
        }
    }
}
