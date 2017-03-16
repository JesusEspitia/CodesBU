namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionU : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DelayWorks", "ReportNo", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DelayWorks", "ReportNo");
        }
    }
}
