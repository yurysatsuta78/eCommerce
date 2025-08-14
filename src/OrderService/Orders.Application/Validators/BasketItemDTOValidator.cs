using FluentValidation;
using Orders.Application.DTOs.BasketDTOs;

namespace Orders.Application.Validators
{
    public class BasketItemDTOValidator : AbstractValidator<BasketItemDTO>
    {
        public BasketItemDTOValidator() 
        {
            RuleFor(item => item.ItemId)
                .NotEmpty()
                .NotEqual(Guid.Empty);

            RuleFor(item => item.Quantity)
                .GreaterThan(0);
        }
    }
}
