using Catalog.BLL.DTOs.Request.CatalogCategory;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogCategory
{
    public class UpdateCategoryRequestValidator : AbstractValidator<UpdateCategoryRequest>
    {
        public UpdateCategoryRequestValidator()
        {
            RuleFor(dto => dto.Name)
                .MinimumLength(1)
                .MaximumLength(50);
        }
    }
}
