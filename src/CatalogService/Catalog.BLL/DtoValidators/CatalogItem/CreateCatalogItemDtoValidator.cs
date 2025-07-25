using Catalog.BLL.Dto.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogItem
{
    public class CreateCatalogItemDtoValidator : AbstractValidator<CreateCatalogItemDto>
    {
        public CreateCatalogItemDtoValidator()
        {
            RuleFor(dto => dto.Name)
                .NotNull().WithMessage("Item name cannot be null.")
                .NotEmpty().WithMessage("Item name cannot be empty.")
                .MinimumLength(1).WithMessage("Item name must be at least 1 character long.")
                .MaximumLength(50).WithMessage("Item name must not exceed 50 characters.");

            RuleFor(dto => dto.Description)
                .NotNull().WithMessage("Item description cannot be null.")
                .NotEmpty().WithMessage("Item description cannot be empty.")
                .MinimumLength(1).WithMessage("Item description must be at least 1 character long.")
                .MaximumLength(300).WithMessage("Item description must not exceed 300 characters.");

            RuleFor(dto => dto.Price)
                .GreaterThan(0).WithMessage("Item price must be greater than zero.");

            RuleFor(dto => dto.RestockThreshold)
                .GreaterThan(0).WithMessage("Restock threshold must be greater than zero.");

            RuleFor(dto => dto.MaxStockThreshold)
                .GreaterThan(0).WithMessage("Max stock threshold must be greater than zero.");

            RuleFor(dto => dto.BrandId)
                .NotEqual(Guid.Empty).WithMessage("Brand ID must be a valid GUID.");

            RuleFor(dto => dto.CategoryId)
                .NotEqual(Guid.Empty).WithMessage("Category ID must be a valid GUID.");

            RuleFor(dto => dto)
                .Must(dto => dto.RestockThreshold < dto.MaxStockThreshold)
                .WithMessage("Restock threshold must be less than max stock threshold.");
        }
    }
}
