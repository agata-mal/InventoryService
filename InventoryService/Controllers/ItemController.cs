﻿using AutoMapper;
using InventoryService.ApiConsumer;
using InventoryService.ApiConsumer.Models;
using InventoryService.Models;
using InventoryService.Models.ApiModels;
using InventoryService.Service.Interfaces;
using InventoryService.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InventoryService.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _itemService;
        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        // GET: Item
        public ActionResult ItemIndex()
        {
            var itemList = _itemService.GetAllItems();
            var vmItemList = new List<VM_Item>();
            Mapper.Map(itemList, vmItemList);
            return View("ItemList", vmItemList);
        }
        public ActionResult CreateNewItem()
        {
            return View("CreateItem");
        }
        public ActionResult EditItem(int id)
        {
            var editItem = _itemService.GetItemById(id);
            var editVMItem = new VM_Item();
            Mapper.Map(editItem, editVMItem);
            return View("EditItem", editVMItem);
        }
        public ActionResult DeleteItem(int id)
        {
            var deleteItem = _itemService.GetItemById(id);
            var deleteVMItem = new VM_Item();
            Mapper.Map(deleteItem, deleteVMItem);
            return View("DeleteItem", deleteVMItem);
        }


        [HttpPost]
        public ActionResult CreateNewItem(VM_Item model)
        {
            var newItem = new Item();
            Mapper.Map(model, newItem);
            _itemService.CreateItem(newItem);
            return RedirectToAction("ItemIndex", "Item");
        }
        [HttpPost]
        public ActionResult EditItem(VM_Item model)
        {
            var editItem = new Item();
            Mapper.Map(model, editItem);
            _itemService.EditItem(editItem);
            return RedirectToAction("ItemIndex", "Item");
        }
        [HttpPost]
        public ActionResult DeleteItem(VM_Item model)
        {
            var deleteItem = new Item();
            Mapper.Map(model, deleteItem);
            _itemService.DeleteItem(deleteItem);
            return RedirectToAction("ItemIndex", "Item");
        }
        public async Task<FileResult> CreatePdf()
        {
            var client = new PdfClient();
            client.SetUrl("http://localhost:55892/api/PDFGeneration");
            var inputModel = new PDFRaportInputModel();
            inputModel.ItemList = new List<ItemModel>();
            Mapper.Map(_itemService.GetAllItems(), inputModel.ItemList);
            var file = await client.PostWithFile(inputModel);
            return File(file, "application/pdf");
        }


    }
}