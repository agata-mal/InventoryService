using System.Data.Entity;


namespace InventoryService.Models
{
    public class ShopContext: DbContext
    {
        public ShopContext(): base("ShopConnection")
        {
        }
        public DbSet<Item>Items { get; set; }

    }
}