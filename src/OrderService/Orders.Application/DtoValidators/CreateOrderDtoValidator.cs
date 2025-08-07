using FluentValidation;
using Orders.Application.Dto.Request;

namespace Orders.Application.DtoValidators
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator() 
        {
            RuleFor(dto => dto.OrderItems)
                .NotEmpty();

            RuleForEach(dto => dto.OrderItems)
                .SetValidator(new CreateOrderItemDtoValidator());
        }
    }
}
