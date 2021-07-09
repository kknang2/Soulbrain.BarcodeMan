namespace Soulbrain.BarcodeMan.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_Cavity_Nullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("QRP.MASProduct", "Cavity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("QRP.MASProduct", "Cavity", c => c.Int(nullable: false));
        }
    }
}
