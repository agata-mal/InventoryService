using InventoryService.Models;
using System.Collections.Generic;

namespace InventoryService.Service.Interfaces
{
    public interface IItemService
    {
        void CreateItem(Item model);
        List<Item> GetAllItems();
        Item GetItemById(int id);
        void EditItem(Item model);
        void DeleteItem(Item model);
        Item GetItemByItemNumber(double data);
    }
}
