using Catalog.BLL.DTOs.CategoryDTOs;
using FluentValidation;

namespace Catalog.BLL.Validators.CategoryValidators
{
    public class GetFilteredCategoriesDTOValidator : AbstractValidator<GetFilteredCategoriesDTO>
    {
        public GetFilteredCategoriesDTOValidator()
        {
            RuleFor(dto => dto.Name)
                .MaximumLength(50);

            RuleFor(dto => dto.PageNumber)
                .GreaterThan(0);

            RuleFor(dto => dto.PageSize)
                .GreaterThan(0)
                .LessThanOrEqualTo(30);
        }
    }
}
