using iText.Layout.Element;

namespace InventoryService.Service
{
    public class PdfService
    {
        private readonly ItemService _itemService;
        public PdfService()
        {
            _itemService = new ItemService();
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
                var cell = new Cell().Add(new Paragraph($"{item.RealAmount - item.ExpectedAmount}"));
                cell.SetUnderline();
                tableLayout.AddCell(cell);

            }

            return tableLayout;

        }

    }
}