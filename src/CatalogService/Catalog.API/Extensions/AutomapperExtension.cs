using Catalog.BLL.MappingProfiles.ProductProfiles;

namespace Catalog.API.Extensions
{
    public static class AutomapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(assembly => assembly.AddMaps(typeof(ProductProfile).Assembly));

            return services;
        }
    }
}
