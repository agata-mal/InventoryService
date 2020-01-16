using iText.Layout.Element;

namespace InventoryService.Service.Interfaces
{
    public interface IPdfService
    {
        Paragraph AddTextToPdf();
        Table AddTableToPdf();
        Cell GetDifferenceCell(double? realAmount, double expectedAmount);
    }
}
