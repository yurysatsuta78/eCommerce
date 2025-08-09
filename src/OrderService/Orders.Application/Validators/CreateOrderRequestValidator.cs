using FluentValidation;
using Orders.Application.DTOs.Request;

namespace Orders.Application.Validators
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(dto => dto.OrderItems)
                .NotEmpty()
                .Must(NoDuplicateItems).WithMessage("OrderItems содержит дублирующиеся ItemId.");

            RuleForEach(dto => dto.OrderItems)
                .SetValidator(new CreateOrderItemRequestValidator());
        }

        private bool NoDuplicateItems(List<CreateOrderItemRequest> items)
        {
            var distinctCount = items.Select(i => i.ItemId).Distinct().Count();
            return distinctCount == items.Count;
        }
    }
}
