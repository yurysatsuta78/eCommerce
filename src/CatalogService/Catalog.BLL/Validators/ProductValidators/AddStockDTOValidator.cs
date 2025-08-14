using Catalog.BLL.DTOs.ProductDTOs.Stock;
using FluentValidation;

namespace Catalog.BLL.Validators.ProductValidators
{
    public class AddStockDTOValidator : AbstractValidator<AddStockDTO>
    {
        public AddStockDTOValidator() 
        {
            RuleFor(dto => dto.Quantity)
                .GreaterThan(0);
        }
    }
}
