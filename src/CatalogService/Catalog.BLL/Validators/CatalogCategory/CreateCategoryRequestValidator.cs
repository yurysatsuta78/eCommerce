using Catalog.BLL.DTOs.Request.CatalogCategory;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogCategory
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
