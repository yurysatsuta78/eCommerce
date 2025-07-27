using Catalog.BLL.Dto.Request.CatalogCategory;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogCategory
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .MaximumLength(50).WithMessage("Category name must not exceed 50 characters.")
                .MinimumLength(1).WithMessage("Category name must be at least 1 character long.");
        }
    }
}
