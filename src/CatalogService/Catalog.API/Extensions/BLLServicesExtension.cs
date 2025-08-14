using Catalog.BLL.Services.Implementations;
using Catalog.BLL.Services.Interfaces;

namespace Catalog.API.Extensions
{
    public static class BLLServicesExtension
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IProductsService, ProductsService>();
            services.AddScoped<IBrandsService, BrandsService>();
            services.AddScoped<ICategoriesService, CategoriesService>();

            return services;
        }
    }
}
