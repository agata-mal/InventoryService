using InventoryService.Models;
using InventoryService.Models.Repository;
using InventoryService.Models.Repository.Interfaces;
using InventoryService.Service.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace InventoryService.Service
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService()
        {
            _itemRepository = new ItemRepository();
        }
        public void CreateItem(Item model)
        {
            _itemRepository.Create(model);
        }
        public List<Item> GetAllItems()
        {
            var list = _itemRepository.GetWhere(x => x.Id > 0);
            return list;
        }
        public Item GetItemById(int id)
        {
            return _itemRepository.GetWhere(x => x.Id == id).FirstOrDefault();
        }
        public void EditItem(Item model)
        {
            _itemRepository.Edit(model);
        }
        public void DeleteItem(Item model)
        {
            _itemRepository.Delete(model);
        }

    }
}