using Microsoft.Extensions.DependencyInjection;

namespace Order.Infrastructure.DI
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services) 
        {
            services.AddAutoMapper(assembly => assembly.AddMaps(typeof(AutoMapperExtension).Assembly));

            return services;
        }
    }
}
