using InventoryService.Service.Interfaces;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;

namespace InventoryService.Service
{
    public class PdfService : IPdfService
    {
        private readonly IItemService _itemService;
        public PdfService(IItemService itemService)
        {
            _itemService = itemService;
        }

        public Paragraph AddTextToPdf()
        {
            var text = new Text("Raport stanów");
            var paragraph = new Paragraph().SetFontSize(20)
                                            .Add(text);
            return paragraph;
        }
        public Table AddTableToPdf()
        {
            float[] columnWidth = { 50, 200, 100, 100, 100 };
            Table tableLayout = new Table(columnWidth);
            tableLayout.SetTextAlignment(TextAlignment.CENTER);
            tableLayout.AddHeaderCell("kod produktu");
            tableLayout.AddHeaderCell("nazwa produktu");
            tableLayout.AddHeaderCell("oczekiwana ilosc");
            tableLayout.AddHeaderCell("rzeczywista ilosc");
            tableLayout.AddHeaderCell("roznica");

            var items = _itemService.GetAllItems();

            foreach (var item in items)
            {

                tableLayout.AddCell(item.ItemNumber.ToString());
                tableLayout.AddCell(item.ItemName);
                tableLayout.AddCell(item.ExpectedAmount.ToString());
                tableLayout.AddCell(item.RealAmount.ToString());
                tableLayout.AddCell(GetDifferenceCell(item.RealAmount, item.ExpectedAmount));
            }

            return tableLayout;

        }
        public Cell GetDifferenceCell(double? realAmount, double expectedAmount)
        {
            var difference = realAmount - expectedAmount;
            var cell = new Cell();
            if (difference < 0)
            {
                cell.Add(new Paragraph("- " + Math.Abs(difference.Value).ToString()));
                cell.SetBold();

            }
            else
                cell.Add(new Paragraph(difference.ToString()));
            return cell;
        }

    }
}