namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracion1505 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrdenComments", "dateComment", c => c.DateTime(nullable: false, precision: 0));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrdenComments", "dateComment");
        }
    }
}
