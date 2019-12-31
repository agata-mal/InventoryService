namespace InventoryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_ExpectedAmount_Add_RealAmount_ItemModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "ExpectedAmount", c => c.Double(nullable: false));
            AddColumn("dbo.Items", "RealAmount", c => c.Double());
            DropColumn("dbo.Items", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "Amount", c => c.Double(nullable: false));
            DropColumn("dbo.Items", "RealAmount");
            DropColumn("dbo.Items", "ExpectedAmount");
        }
    }
}
