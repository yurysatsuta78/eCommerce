using Catalog.BLL.DTOs.Request.CatalogItem;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogItem
{
    public class UpdateCatalogItemRequestValidator : AbstractValidator<UpdateCatalogItemRequest>
    {
        public UpdateCatalogItemRequestValidator() 
        {
            RuleFor(dto => dto.Name)
                .MinimumLength(1)
                .MaximumLength(50);

            RuleFor(dto => dto.Description)
                .MinimumLength(1)
                .MaximumLength(300);

            RuleFor(dto => dto.Price)
                .GreaterThan(0)
                .When(dto => dto.Price.HasValue);
        }
    }
}
