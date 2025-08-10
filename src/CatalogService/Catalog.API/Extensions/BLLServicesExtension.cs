using Catalog.BLL.Services.Implementations;
using Catalog.BLL.Services.Interfaces;

namespace Catalog.API.Extensions
{
    public static class BLLServicesExtension
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<ICatalogItemService, CatalogItemService>();
            services.AddScoped<ICatalogBrandService, CatalogBrandService>();
            services.AddScoped<ICatalogCategoryService, CatalogCategoryService>();

            return services;
        }
    }
}
