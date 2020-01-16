using AutoMapper;
using InventoryService.Service.Interfaces;
using InventoryService.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InventoryService.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IItemService _itemService;
        public InventoryController(IItemService itemService)
        {
            _itemService = itemService;
        }
        // GET: Inventory
        public ActionResult ShowItemsToInventory()
        {
            var itemsToINventory = _itemService.GetAllItems();
            var vmItemsToInventory = new List<VM_Item>();
            Mapper.Map(itemsToINventory, vmItemsToInventory);
            return View("InventoryView", vmItemsToInventory);
        }


        public JsonResult SaveRealAmount(int id, double realAmount)
        {
            var item = _itemService.GetItemById(id);
            if (item != null)
            {
                item.RealAmount = realAmount;
                _itemService.EditItem(item);
                return Json("OK", JsonRequestBehavior.AllowGet);
            }


            return Json("ERROR", JsonRequestBehavior.AllowGet);
        }

        
    }
}