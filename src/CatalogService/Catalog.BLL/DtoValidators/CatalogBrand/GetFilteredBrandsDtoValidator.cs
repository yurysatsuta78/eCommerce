using Catalog.BLL.Dto.Request.CatalogBrand;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogBrand
{
    public class GetFilteredBrandsDtoValidator : AbstractValidator<GetFilteredBrandsDto>
    {
        public GetFilteredBrandsDtoValidator() 
        {
            RuleFor(dto => dto.Name)
                .MaximumLength(50).WithMessage("Brand name filter must not exceed 50 characters.");

            RuleFor(dto => dto.PageNumber)
                .GreaterThan(0).WithMessage("Page number must be greater than zero.");

            RuleFor(dto => dto.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than zero.")
                .LessThanOrEqualTo(30).WithMessage("Page size must be less than of equal to 30.");
        }
    }
}
