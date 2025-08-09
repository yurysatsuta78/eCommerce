using FluentValidation.AspNetCore;
using FluentValidation;
using Basket.BLL.Validators;

namespace Basket.API.Extensions
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(BasketDTOValidator).Assembly);

            return services;
        }
    }
}
