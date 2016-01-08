namespace Tales.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPublishedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PublishedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "PublishedDate");
        }
    }
}
