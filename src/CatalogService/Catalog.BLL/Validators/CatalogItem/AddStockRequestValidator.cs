using Catalog.BLL.DTOs.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogItem
{
    public class AddStockRequestValidator : AbstractValidator<AddStockRequest>
    {
        public AddStockRequestValidator() 
        {
            RuleFor(dto => dto.Quantity)
                .GreaterThan(0);
        }
    }
}
