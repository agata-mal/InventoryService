using InventoryService.Enums;
using iText.Layout.Element;
using iText.Layout.Properties;
using PDFServiceAPI.Models;
using PDFServiceAPI.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace PDFServiceAPI.Service
{
    public class PdfService : IPdfService
    {
        public Paragraph AddTextToPdf()
        {
            var text = new Text("Raport stanów");
            var paragraph = new Paragraph().SetFontSize(20)
                                            .Add(text);
            return paragraph;
        }
        public Table AddTableToPdf(List<ItemModel> items)
        {
            float[] columnWidth = { 50, 100,100, 100, 100, 50 };
            Table tableLayout = new Table(columnWidth);
            tableLayout.SetTextAlignment(TextAlignment.CENTER);
            tableLayout.AddHeaderCell("kod produktu");
            tableLayout.AddHeaderCell("nazwa produktu");
            tableLayout.AddHeaderCell("Jm");
            tableLayout.AddHeaderCell("oczekiwana ilosc");
            tableLayout.AddHeaderCell("rzeczywista ilosc");
            tableLayout.AddHeaderCell("roznica");

            foreach (var item in items)
            {
                tableLayout.AddCell(item.ItemNumber.ToString());
                tableLayout.AddCell(item.ItemName);
                tableLayout.AddCell(item.Unit.GetDisplayName());
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