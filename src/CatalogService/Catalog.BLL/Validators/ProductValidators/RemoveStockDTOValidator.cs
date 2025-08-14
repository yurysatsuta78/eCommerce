using Catalog.BLL.DTOs.ProductDTOs.Stock;
using FluentValidation;

namespace Catalog.BLL.Validators.ProductValidators
{
    public class RemoveStockDTOValidator : AbstractValidator<RemoveStockDTO>
    {
        public RemoveStockDTOValidator() 
        {
            RuleFor(dto => dto.Quantity)
                .GreaterThan(0);
        }
    }
}
