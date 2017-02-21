namespace Monotoring.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracionJ : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Catalogs", "image", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Catalogs", "image", c => c.Binary());
        }
    }
}
