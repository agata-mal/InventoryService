namespace InventoryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodanie_jednostek_miary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Items", "Unit", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Items", "Unit");
        }
    }
}
