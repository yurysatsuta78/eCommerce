using Catalog.BLL.Dto.Request.CatalogBrand;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogBrand
{
    public class UpdateBrandDtoValidator : AbstractValidator<UpdateBrandDto>
    {
        public UpdateBrandDtoValidator() 
        {
            RuleFor(dto => dto.Name)
                .NotNull().WithMessage("Brand name cannot be null.")
                .NotEmpty().WithMessage("Brand name cannot be empty.")
                .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters.")
                .MinimumLength(1).WithMessage("Brand name must be at least 1 character long.");
        }
    }
}
