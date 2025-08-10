using Catalog.BLL.DTOs.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogItem
{
    public class CreateCatalogItemRequestValidator : AbstractValidator<CreateCatalogItemRequest>
    {
        public CreateCatalogItemRequestValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(dto => dto.Description)
                .NotEmpty()
                .MaximumLength(300);

            RuleFor(dto => dto.Price)
                .GreaterThan(0);

            RuleFor(dto => dto.RestockThreshold)
                .GreaterThan(0);

            RuleFor(dto => dto.MaxStockThreshold)
                .GreaterThan(0)
                .DependentRules(() => 
                {
                    RuleFor(dto => dto)
                    .Must(dto => dto.RestockThreshold < dto.MaxStockThreshold);
                });

            RuleFor(dto => dto.BrandId)
                .NotEqual(Guid.Empty);

            RuleFor(dto => dto.CategoryId)
                .NotEqual(Guid.Empty);
        }
    }
}
