using Basket.BLL.DTOs;
using FluentValidation;

namespace Basket.BLL.Validators
{
    public class BasketDTOValidator : AbstractValidator<BasketDTO>
    {
        public BasketDTOValidator() 
        {
            RuleFor(dto => dto.BasketItems)
                .NotEmpty()
                .Must(NoDuplicateItems).WithMessage("BasketItems содержит дублирующиеся ItemId.");

            RuleForEach(dto => dto.BasketItems)
                .SetValidator(new BasketItemDTOValidator());
        }

        private bool NoDuplicateItems(List<BasketItemDTO> basketItems)
        {
            var distinctCount = basketItems.Select(i => i.ItemId).Distinct().Count();
            return distinctCount == basketItems.Count;
        }
    }
}
