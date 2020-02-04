namespace InventoryService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usuniecieNullableUnit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Items", "Unit", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Items", "Unit", c => c.Int());
        }
    }
}
