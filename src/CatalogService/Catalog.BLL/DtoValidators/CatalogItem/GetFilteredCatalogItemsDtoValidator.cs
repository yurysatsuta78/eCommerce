using Catalog.BLL.Dto.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogItem
{
    public class GetFilteredCatalogItemsDtoValidator : AbstractValidator<GetFilteredCatalogItemsDto>
    {
        public GetFilteredCatalogItemsDtoValidator() 
        {
            RuleFor(dto => dto.Name)
                .MaximumLength(50).WithMessage("Item name filter must not exceed 50 characters.");

            RuleFor(dto => dto.MinPrice)
                .GreaterThanOrEqualTo(0)
                .When(dto => dto.MinPrice.HasValue)
                .WithMessage("Item min price filter must be greater than or equal to zero.");

            RuleFor(dto => dto.MaxPrice)
                .GreaterThan(0)
                .When(dto => dto.MaxPrice.HasValue)
                .WithMessage("Item max price filter must be greater than zero.");

            RuleFor(dto => dto.BrandId)
                .NotEqual(Guid.Empty)
                .When(dto => dto.BrandId.HasValue)
                .WithMessage("Brand ID must be a valid GUID.");

            RuleFor(dto => dto.CategoryId)
                .NotEqual(Guid.Empty)
                .When(dto => dto.CategoryId.HasValue)
                .WithMessage("Category ID must be a valid GUID.");

            RuleFor(dto => dto.PageNumber)
                .GreaterThan(0).WithMessage("Page number must be greater than zero.");

            RuleFor(dto => dto.PageSize)
                .GreaterThan(0).WithMessage("Page size must be greater than zero.")
                .LessThanOrEqualTo(30).WithMessage("Page size must be less than of equal to 30.");

            RuleFor(dto => dto)
                .Must(dto => !dto.MinPrice.HasValue || !dto.MaxPrice.HasValue || dto.MinPrice < dto.MaxPrice)
                .WithMessage("Filter min price must be less than filter max price.");
        }
    }
}
