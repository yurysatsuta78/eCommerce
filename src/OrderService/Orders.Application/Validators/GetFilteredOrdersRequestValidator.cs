using FluentValidation;
using Orders.Application.DTOs.Request;

namespace Orders.Application.Validators
{
    public class GetFilteredOrdersRequestValidator : AbstractValidator<GetFilteredOrdersRequest>
    {
        public GetFilteredOrdersRequestValidator() 
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
