using Catalog.BLL.Dto.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogItem
{
    public class RemoveStockDtoValidator : AbstractValidator<RemoveStockDto>
    {
        public RemoveStockDtoValidator() 
        {
            RuleFor(dto => dto.QuantityDesired)
                .GreaterThan(0).WithMessage("Quantity desired must be greater than zero.");
        }
    }
}
