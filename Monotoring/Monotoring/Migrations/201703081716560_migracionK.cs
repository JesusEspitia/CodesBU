namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionK : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Areas", "orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Areas", "orden");
        }
    }
}
