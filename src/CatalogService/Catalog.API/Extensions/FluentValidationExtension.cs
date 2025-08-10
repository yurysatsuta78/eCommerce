using Catalog.BLL.Validators.CatalogItem;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace Catalog.API.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateCatalogItemRequestValidator>();

            return services;
        }
    }
}
