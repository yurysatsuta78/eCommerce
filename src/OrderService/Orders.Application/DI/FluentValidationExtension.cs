using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Orders.Application.DI
{
    public static class FluentValidationExtension
    {
        public static IServiceCollection AddValidators(this IServiceCollection services) 
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(typeof(FluentValidationExtension).Assembly);

            return services;
        }
    }
}
