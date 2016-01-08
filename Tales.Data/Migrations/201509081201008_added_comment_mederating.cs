namespace Tales.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_comment_mederating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "IsModerated", c => c.Boolean(nullable: false));
            AddColumn("dbo.Comments", "IsValid", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "IsValid");
            DropColumn("dbo.Comments", "IsModerated");
        }
    }
}
