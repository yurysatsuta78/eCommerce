using Catalog.BLL.DTOs.CategoryDTOs;
using FluentValidation;

namespace Catalog.BLL.Validators.CategoryValidators
{
    public class UpdateCategoryDTOValidator : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .MinimumLength(1)
                .MaximumLength(50);
        }
    }
}
