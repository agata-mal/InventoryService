using InventoryService.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryService.Models

{
    public class Item
    {
        public int Id { get; set; }
        [Index("ItemNumber", IsUnique = true)]
        [Range(1,9999)]
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public Unit Unit { get; set; }
        public double ExpectedAmount { get; set; }
        public double? RealAmount { get; set; }
    }
}