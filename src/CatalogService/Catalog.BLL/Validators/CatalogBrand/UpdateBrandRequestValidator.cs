using Catalog.BLL.DTOs.Request.CatalogBrand;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogBrand
{
    public class UpdateBrandRequestValidator : AbstractValidator<UpdateBrandRequest>
    {
        public UpdateBrandRequestValidator() 
        {
            RuleFor(dto => dto.Name)
                .MinimumLength(1)
                .MaximumLength(50);
        }
    }
}
