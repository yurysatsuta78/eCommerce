using FluentValidation;
using Orders.Application.DTOs.OrderDTOs;

namespace Orders.Application.Validators
{
    public class GetFilteredOrdersDTOValidator : AbstractValidator<GetFilteredOrdersDTO>
    {
        public GetFilteredOrdersDTOValidator() 
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
