namespace InventoryService.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public double InStock { get; set; }
    }
}