using InventoryService.Enums;

namespace InventoryService.ApiConsumer.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public Unit Unit { get; set; }
        public double ExpectedAmount { get; set; }
        public double? RealAmount { get; set; }
    }
}