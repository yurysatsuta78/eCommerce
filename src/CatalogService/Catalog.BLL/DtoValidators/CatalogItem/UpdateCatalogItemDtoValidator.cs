using Catalog.BLL.Dto.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.DtoValidators.CatalogItem
{
    public class UpdateCatalogItemDtoValidator : AbstractValidator<UpdateCatalogItemDto>
    {
        public UpdateCatalogItemDtoValidator() 
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
                .GreaterThan(0)
                .When(dto => dto.Price.HasValue)
                .WithMessage("Item price must be greater than zero.");
        }
    }
}
