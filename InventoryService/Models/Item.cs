using FluentValidation.Attributes;
using InventoryService.Enums;
using InventoryService.Validation;
using System.ComponentModel.DataAnnotations.Schema;
namespace InventoryService.Models

{
    [Validator(typeof(ItemValidator))]
    public class Item
    {
        public int Id { get; set; }
        [Index("ItemNumber", IsUnique = true)]
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public Unit Unit { get; set; }
        public double ExpectedAmount { get; set; }
        public double? RealAmount { get; set; }
    }
}