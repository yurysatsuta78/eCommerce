using Catalog.BLL.DTOs.BrandDTOs;
using FluentValidation;

namespace Catalog.BLL.Validators.BrandValidators
{
    public class UpdateBrandDTOValidator : AbstractValidator<UpdateBrandDTO>
    {
        public UpdateBrandDTOValidator() 
        {
            RuleFor(dto => dto.Name)
                .MinimumLength(1)
                .MaximumLength(50);
        }
    }
}
