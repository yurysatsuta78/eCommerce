using FluentValidation;
using Orders.Application.DTOs.Request;

namespace Orders.Application.Validators
{
    public class CreateOrderItemRequestValidator : AbstractValidator<CreateOrderItemRequest>
    {
        public CreateOrderItemRequestValidator() 
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
