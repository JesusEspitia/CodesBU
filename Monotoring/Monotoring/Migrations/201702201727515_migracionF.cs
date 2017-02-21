namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionF : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogs", "image", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Catalogs", "image");
        }
    }
}
