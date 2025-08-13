using Catalog.BLL.Dto.Request.CatalogBrand;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogBrand
{
    public class UpdateBrandDtoValidator : AbstractValidator<UpdateBrandDto>
    {
        public UpdateBrandDtoValidator() 
        {
            RuleFor(dto => dto.Name)
                .MinimumLength(1).WithMessage("Brand name must be at least 1 character long.")
                .MaximumLength(50).WithMessage("Brand name must not exceed 50 characters.");
        }
    }
}
