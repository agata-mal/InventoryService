using iText.Layout.Element;

namespace InventoryService.Service.Interfaces
{
    interface IPdfService
    {
        Paragraph AddTextToPdf();
        Table AddTableToPdf();
        Cell GetDifferenceCell(double? realAmount, double expectedAmount);
    }
}
