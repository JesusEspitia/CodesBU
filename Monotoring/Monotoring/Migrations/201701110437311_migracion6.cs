namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WorkOrdens", "ordenCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WorkOrdens", "ordenCount", c => c.Int());
        }
    }
}
