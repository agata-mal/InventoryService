namespace InventoryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WalidacjaPolaIZminaNazwPola : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Amount", c => c.Double(nullable: false));
            CreateIndex("dbo.Items", "ItemNumber", unique: true, name: "ItemNumber");
            DropColumn("dbo.Items", "InStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "InStock", c => c.Double(nullable: false));
            DropIndex("dbo.Items", "ItemNumber");
            DropColumn("dbo.Items", "Amount");
        }
    }
}
