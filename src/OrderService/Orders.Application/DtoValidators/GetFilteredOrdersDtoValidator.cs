using FluentValidation;
using Orders.Application.Dto.Request;

namespace Orders.Application.DtoValidators
{
    public class GetFilteredOrdersDtoValidator : AbstractValidator<GetFilteredOrdersDto>
    {
        public GetFilteredOrdersDtoValidator() 
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
