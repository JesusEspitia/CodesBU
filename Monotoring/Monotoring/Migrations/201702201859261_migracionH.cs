namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionH : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogs", "image", c => c.Binary());
            DropColumn("dbo.Catalogs", "imageCatalog");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Catalogs", "imageCatalog", c => c.String(unicode: false));
            DropColumn("dbo.Catalogs", "image");
        }
    }
}
