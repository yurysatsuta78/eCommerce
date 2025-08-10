using Catalog.BLL.MappingProfiles.CatalogItemMappingProfiles;

namespace Catalog.API.Extensions
{
    public static class AutomapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(assembly => assembly.AddMaps(typeof(CatalogItemProfile).Assembly));

            return services;
        }
    }
}
