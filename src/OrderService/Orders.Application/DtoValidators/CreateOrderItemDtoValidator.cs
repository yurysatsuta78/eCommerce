using FluentValidation;
using Orders.Application.Dto.Request;

namespace Orders.Application.DtoValidators
{
    public class CreateOrderItemDtoValidator : AbstractValidator<CreateOrderItemDto>
    {
        public CreateOrderItemDtoValidator() 
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
