using InventoryService.Enums;
using System.ComponentModel.DataAnnotations;

namespace InventoryService.ViewModels
{
    public class VM_Item
    {
        public int Id { get; set; }
        [Range(1,9999)]
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public Unit Unit { get; set; }
        public double ExpectedAmount { get; set; }
        public double? RealAmount { get; set; }
    }
}