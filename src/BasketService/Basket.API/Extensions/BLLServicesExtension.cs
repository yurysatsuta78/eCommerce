using Basket.BLL.Services.Implementations;
using Basket.BLL.Services.Interfaces;

namespace Basket.API.Extensions
{
    public static class BLLServicesExtension
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services) 
        {
            services.AddScoped<IBasketService, BasketService>();

            return services;
        }
    }
}
