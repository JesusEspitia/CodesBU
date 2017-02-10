namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DelayComments", "dateComment", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DelayComments", "dateComment");
        }
    }
}
