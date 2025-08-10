using Catalog.BLL.DTOs.Request.CatalogBrand;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogBrand
{
    public class GetFilteredBrandsRequestValidator : AbstractValidator<GetFilteredBrandsRequest>
    {
        public GetFilteredBrandsRequestValidator() 
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
