using Catalog.BLL.Dto.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogItem
{
    public class AddStockDtoValidator : AbstractValidator<AddStockDto>
    {
        public AddStockDtoValidator() 
        {
            RuleFor(dto => dto.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        }
    }
}
