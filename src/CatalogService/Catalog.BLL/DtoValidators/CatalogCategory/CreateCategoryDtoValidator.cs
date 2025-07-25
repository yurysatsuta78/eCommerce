using Catalog.BLL.Dto.Request.CatalogCategory;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogCategory
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotNull().WithMessage("Category name cannot be null.")
                .NotEmpty().WithMessage("Category name cannot be empty.")
                .MaximumLength(50).WithMessage("Category name must not exceed 50 characters.")
                .MinimumLength(1).WithMessage("Category name must be at least 1 character long.");
        }
    }
}
