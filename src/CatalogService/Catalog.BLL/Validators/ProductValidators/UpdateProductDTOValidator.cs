using Catalog.BLL.DTOs.ProductDTOs;
using FluentValidation;

namespace Catalog.BLL.Validators.ProductValidators
{
    public class UpdateProductDTOValidator : AbstractValidator<UpdateProductDTO>
    {
        public UpdateProductDTOValidator() 
        {
            RuleFor(dto => dto.Name)
                .MinimumLength(1)
                .MaximumLength(50);

            RuleFor(dto => dto.Description)
                .MinimumLength(1)
                .MaximumLength(300);

            RuleFor(dto => dto.Price)
                .GreaterThan(0)
                .When(dto => dto.Price.HasValue);
        }
    }
}
