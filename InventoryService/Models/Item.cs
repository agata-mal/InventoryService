using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryService.Models

{
    public class Item
    {
        public int Id { get; set; }
        [Index("ItemNumber", IsUnique = true)]
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public double Amount { get; set; }
    }
}