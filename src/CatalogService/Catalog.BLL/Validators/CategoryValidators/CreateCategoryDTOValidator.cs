using Catalog.BLL.DTOs.CategoryDTOs;
using FluentValidation;

namespace Catalog.BLL.Validators.CategoryValidators
{
    public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
