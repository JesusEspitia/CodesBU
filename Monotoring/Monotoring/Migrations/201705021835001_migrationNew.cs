namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationNew : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Area_Orden", "notify", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Area_Orden", "notify");
        }
    }
}
