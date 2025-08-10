using Catalog.BLL.DTOs.Request.CatalogBrand;
using FluentValidation;

namespace Catalog.BLL.Validators.CatalogBrand
{
    public class CreateBrandRequestValidator : AbstractValidator<CreateBrandRequest>
    {
        public CreateBrandRequestValidator() 
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
