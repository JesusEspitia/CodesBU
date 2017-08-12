namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migraciona : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DelayWorks", "ReportNo", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DelayWorks", "ReportNo", c => c.Int());
        }
    }
}
