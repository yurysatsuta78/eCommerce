using Catalog.BLL.DTOs.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogItem
{
    public class RemoveStockRequestValidator : AbstractValidator<RemoveStockRequest>
    {
        public RemoveStockRequestValidator() 
        {
            RuleFor(dto => dto.QuantityDesired)
                .GreaterThan(0);
        }
    }
}
