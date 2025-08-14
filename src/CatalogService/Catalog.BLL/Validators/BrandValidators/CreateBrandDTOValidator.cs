using Catalog.BLL.DTOs.BrandDTOs;
using FluentValidation;

namespace Catalog.BLL.Validators.BrandValidators
{
    public class CreateBrandDTOValidator : AbstractValidator<CreateBrandDTO>
    {
        public CreateBrandDTOValidator() 
        {
            RuleFor(dto => dto.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
