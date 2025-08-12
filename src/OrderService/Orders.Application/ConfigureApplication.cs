using Microsoft.Extensions.DependencyInjection;
using Orders.Application.DI;

namespace Orders.Application
{
    public static class ConfigureApplication
    {
        public static IServiceCollection AddApplication(this IServiceCollection services) 
        {
            services.AddBLServices();
            services.AddValidators();
            services.AddMediatR();

            return services;
        }
    }
}
