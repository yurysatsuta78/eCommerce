using Catalog.BLL.DTOs.Request.CatalogCategory;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogCategory
{
    public class GetFilteredCategoriesRequestValidator : AbstractValidator<GetFilteredCategoriesRequest>
    {
        public GetFilteredCategoriesRequestValidator()
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
