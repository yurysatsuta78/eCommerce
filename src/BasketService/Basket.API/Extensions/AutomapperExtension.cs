using Basket.BLL.MappingProfiles;

namespace Basket.API.Extensions
{
    public static class AutomapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services) 
        {
            services.AddAutoMapper(assembly => assembly.AddMaps(typeof(BasketProfile).Assembly));

            return services;
        }
    }
}
