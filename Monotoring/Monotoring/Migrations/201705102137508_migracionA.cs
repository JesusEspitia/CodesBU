namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "active");
        }
    }
}
