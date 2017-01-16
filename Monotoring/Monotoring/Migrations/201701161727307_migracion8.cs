namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Area_Orden", "runOrden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Area_Orden", "runOrden");
        }
    }
}
