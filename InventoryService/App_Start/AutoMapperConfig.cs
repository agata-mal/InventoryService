using AutoMapper;
using InventoryService.ApiConsumer.Models;
using InventoryService.Models;
using InventoryService.ViewModels;

namespace InventoryService.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Item, VM_Item>().ReverseMap();
                cfg.CreateMap<Item, ItemModel>();
            });

        }
    }
}