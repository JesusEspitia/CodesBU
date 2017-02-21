namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionG : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Catalogs", "imageCatalog", c => c.String(unicode: false));
            DropColumn("dbo.Catalogs", "image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Catalogs", "image", c => c.Binary());
            DropColumn("dbo.Catalogs", "imageCatalog");
        }
    }
}
