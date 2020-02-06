using System.ComponentModel.DataAnnotations;

namespace PDFServiceAPI.Enums
{
    public enum Unit
    {
        [Display(Name = "szt")]
        Piece = 1,
        [Display(Name = "kg")]
        Kilogram = 2
    }
}