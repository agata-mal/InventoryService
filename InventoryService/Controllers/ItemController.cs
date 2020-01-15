using AutoMapper;
using InventoryService.Models;
using InventoryService.Service;
using InventoryService.ViewModels;
using iText.Kernel.Pdf;
using iText.Layout;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace InventoryService.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService _itemService;
        private readonly PdfService _pdfService;
        public ItemController()
        {
            _itemService = new ItemService();
            _pdfService = new PdfService();
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
   
        public FileResult CreatePdf()
        {
            using (var memoryStream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(memoryStream);
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document document = new Document(pdfDoc);
                document.Add(_pdfService.AddTextToPdf());
                document.Add(_pdfService.AddTableToPdf());
                document.Close();
                byte[] byteInfo = memoryStream.ToArray();
                return File(byteInfo, "application/pdf");
            }
        }
    }
}