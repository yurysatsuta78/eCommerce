using Catalog.BLL.Dto.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogItem
{
    public class CreateCatalogItemDtoValidator : AbstractValidator<CreateCatalogItemDto>
    {
        public CreateCatalogItemDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotEmpty().WithMessage("Item name cannot be empty.")
                .MaximumLength(50).WithMessage("Item name must not exceed 50 characters.");

            RuleFor(dto => dto.Description)
                .NotEmpty().WithMessage("Item description cannot be empty.")
                .MaximumLength(300).WithMessage("Item description must not exceed 300 characters.");

            RuleFor(dto => dto.Price)
                .GreaterThan(0).WithMessage("Item price must be greater than zero.");

            RuleFor(dto => dto.RestockThreshold)
                .GreaterThan(0).WithMessage("Restock threshold must be greater than zero.");

            RuleFor(dto => dto.MaxStockThreshold)
                .GreaterThan(0).WithMessage("Max stock threshold must be greater than zero.")
                .DependentRules(() => 
                {
                    RuleFor(dto => dto)
                    .Must(dto => dto.RestockThreshold < dto.MaxStockThreshold)
                    .WithMessage("Restock threshold must be less than max stock threshold.");
                });

            RuleFor(dto => dto.BrandId)
                .NotEqual(Guid.Empty).WithMessage("Brand ID must be a valid GUID.");

            RuleFor(dto => dto.CategoryId)
                .NotEqual(Guid.Empty).WithMessage("Category ID must be a valid GUID.");
        }
    }
}
