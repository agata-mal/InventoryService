using InventoryService.Models.Repository.Interfaces;

namespace InventoryService.Models.Repository
{
    public class ItemRepository : AbstractRepository<Item>, IItemRepository
    {
    }
}