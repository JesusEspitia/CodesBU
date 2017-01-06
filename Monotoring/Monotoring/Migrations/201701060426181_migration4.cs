namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Area_Orden", "dateFinish", c => c.DateTime(precision: 0));
            AlterColumn("dbo.WorkOrdens", "dateFinish", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrdens", "dateFinish", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.Area_Orden", "dateFinish", c => c.DateTime(nullable: false, precision: 0));
        }
    }
}
