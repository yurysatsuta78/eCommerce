using FluentValidation;
using Orders.Application.DTOs.Order;

namespace Orders.Application.Validators
{
    public class OrderFilterParamsDTOValidator : AbstractValidator<OrderFilterParamsDTO>
    {
        public OrderFilterParamsDTOValidator() 
        {
            RuleFor(dto => dto.CustomerId)
                .NotEqual(Guid.Empty)
                .When(dto => dto.CustomerId.HasValue);

            RuleFor(dto => dto.PageNumber)
                .GreaterThan(0);

            RuleFor(dto => dto.PageSize)
                .GreaterThan(0)
                .LessThanOrEqualTo(50);
        }
    }
}
