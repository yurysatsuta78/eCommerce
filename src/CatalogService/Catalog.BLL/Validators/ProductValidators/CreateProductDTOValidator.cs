using Catalog.BLL.DTOs.ProductDTOs;
using FluentValidation;

namespace Catalog.BLL.Validators.ProductValidators
{
    public class CreateProductDTOValidator : AbstractValidator<CreateProductDTO>
    {
        public CreateProductDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(dto => dto.Description)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(dto => dto.Price)
                .GreaterThan(0);

            RuleFor(dto => dto.StockCapacity)
                .GreaterThan(0);

            RuleFor(dto => dto.BrandId)
                .NotEqual(Guid.Empty);

            RuleFor(dto => dto.CategoryId)
                .NotEqual(Guid.Empty);
        }
    }
}
