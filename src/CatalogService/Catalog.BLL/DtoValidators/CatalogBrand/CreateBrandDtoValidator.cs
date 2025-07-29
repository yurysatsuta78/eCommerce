using Catalog.BLL.Dto.Request.CatalogBrand;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogBrand
{
    public class CreateBrandDtoValidator : AbstractValidator<CreateBrandDto>
    {
        public CreateBrandDtoValidator() 
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Brand name cannot be empty.")
                .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters.");
        }
    }
}
