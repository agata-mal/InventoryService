using iText.Kernel.Pdf;
using iText.Layout;
using PDFServiceAPI.Models;
using PDFServiceAPI.Service;
using PDFServiceAPI.Service.Interfaces;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PDFServiceAPI.Controllers
{
    public class PDFGenerationController : ApiController
    {
        private readonly IPdfService _pdfService;
        public PDFGenerationController()
        {
            _pdfService = new PdfService();
        }
        [HttpPost]
        public HttpResponseMessage Post(PDFRaportInputModel model)
        {
            var file = CreatePdf(model);

            return Request.CreateResponse(HttpStatusCode.OK, file);
        }




        private byte[] CreatePdf(PDFRaportInputModel inputModel)
        {
            using (var memoryStream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(memoryStream);
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document document = new Document(pdfDoc);
                document.Add(_pdfService.AddTextToPdf());
                document.Add(_pdfService.AddTableToPdf(inputModel.ItemList));
                document.Close();
                return memoryStream.ToArray();
            }
        }
    }
}
