using Catalog.BLL.DTOs.BrandDTOs;
using FluentValidation;

namespace Catalog.BLL.Validators.BrandValidators
{
    public class GetFilteredBrandsDTOValidator : AbstractValidator<GetFilteredBrandsDTO>
    {
        public GetFilteredBrandsDTOValidator() 
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
