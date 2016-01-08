namespace Tales.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_summery_to_post : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Summery", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "Summery");
        }
    }
}
