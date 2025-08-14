using FluentValidation;
using Orders.Application.DTOs.BasketDTOs;

namespace Orders.Application.Validators
{
    public class BasketDTOValidator : AbstractValidator<BasketDTO>
    {
        public BasketDTOValidator()
        {
            RuleFor(dto => dto.BasketItems)
                .NotEmpty()
                .Must(NoDuplicateItems).WithMessage("Корзина содержит позиции с дублирующимися Id.");

            RuleForEach(dto => dto.BasketItems)
                .SetValidator(new BasketItemDTOValidator());
        }

        private bool NoDuplicateItems(List<BasketItemDTO> items)
        {
            var distinctCount = items.Select(i => i.ItemId).Distinct().Count();
            return distinctCount == items.Count;
        }
    }
}
