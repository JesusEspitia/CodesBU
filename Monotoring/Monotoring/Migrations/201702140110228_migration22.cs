namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration22 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "userEmail");
            DropColumn("dbo.Users", "userPass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "userPass", c => c.String(unicode: false));
            AddColumn("dbo.Users", "userEmail", c => c.String(unicode: false));
        }
    }
}
