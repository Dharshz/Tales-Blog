namespace Tales.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserActivation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsActive");
        }
    }
}
