using Basket.BLL.DTOs;
using FluentValidation;

namespace Basket.BLL.Validators
{
    public class BasketItemDTOValidator : AbstractValidator<BasketItemDTO>
    {
        public BasketItemDTOValidator() 
        {
            RuleFor(item => item.ItemId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(item => item.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(item => item.Quantity)
                .GreaterThan(0);

            RuleFor(item => item.Price)
                .GreaterThan(0);
        }
    }
}
