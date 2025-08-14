using FluentValidation.AspNetCore;
using FluentValidation;
using Catalog.BLL.Validators.ProductValidators;

namespace Catalog.API.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateProductDTOValidator>();

            return services;
        }
    }
}
