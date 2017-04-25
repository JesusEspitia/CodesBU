namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "emailuser", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "emailuser");
        }
    }
}
