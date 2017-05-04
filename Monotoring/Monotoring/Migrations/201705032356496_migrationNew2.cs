namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationNew2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserNewRequests", "fullname", c => c.String(unicode: false));
            AddColumn("dbo.UserNewRequests", "email", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserNewRequests", "email");
            DropColumn("dbo.UserNewRequests", "fullname");
        }
    }
}
