using FluentValidation;
using InventoryService.Models;

namespace InventoryService.Validation
{
    public class ItemValidator: AbstractValidator<Item>, IValidator<Item>
    {
        public ItemValidator()
        {
            RuleFor(item => item.ItemNumber).ExclusiveBetween(0, 10000).WithMessage("Kod produktu musi byc w zakresie od 1 do 9999");
            RuleFor(item => item.Unit).NotEmpty().WithMessage("Proszę podać jednostkę");
           

        }

    }
}