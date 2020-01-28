using iText.Layout.Element;
using PDFServiceAPI.Models;
using System.Collections.Generic;

namespace PDFServiceAPI.Service.Interfaces
{
    public interface IPdfService
    {
        Paragraph AddTextToPdf();
        Table AddTableToPdf(List<ItemModel> items);
        Cell GetDifferenceCell(double? realAmount, double expectedAmount);
    }
}
