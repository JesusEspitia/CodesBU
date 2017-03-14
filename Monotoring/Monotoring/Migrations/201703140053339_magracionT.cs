namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class magracionT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DelayWorks", "Responsable", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DelayWorks", "Responsable");
        }
    }
}
