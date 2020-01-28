using InventoryService.ApiConsumer.Models;
using System.Collections.Generic;

namespace InventoryService.Models.ApiModels
{
    public class PDFRaportInputModel
    {
        public List<ItemModel> ItemList { get; set; }
    }
}