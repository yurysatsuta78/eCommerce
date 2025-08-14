using Catalog.BLL.DTOs.ProductDTOs;
using FluentValidation;

namespace Catalog.BLL.Validators.ProductValidators
{
    public class GetFilteredProductsDTOValidator : AbstractValidator<GetFilteredProductsDTO>
    {
        public GetFilteredProductsDTOValidator() 
        {
            RuleFor(dto => dto.Name)
                .MaximumLength(50);

            RuleFor(dto => dto.MinPrice)
                .GreaterThanOrEqualTo(0)
                .When(dto => dto.MinPrice.HasValue);

            RuleFor(dto => dto.MaxPrice)
                .GreaterThan(0)
                .When(dto => dto.MaxPrice.HasValue);

            RuleFor(dto => dto.BrandId)
                .NotEqual(Guid.Empty)
                .When(dto => dto.BrandId.HasValue);

            RuleFor(dto => dto.CategoryId)
                .NotEqual(Guid.Empty)
                .When(dto => dto.CategoryId.HasValue);

            RuleFor(dto => dto.PageNumber)
                .GreaterThan(0);

            RuleFor(dto => dto.PageSize)
                .GreaterThan(0)
                .LessThanOrEqualTo(30);

            RuleFor(dto => dto)
                .Must(dto => !dto.MinPrice.HasValue || !dto.MaxPrice.HasValue || dto.MinPrice < dto.MaxPrice);
        }
    }
}
