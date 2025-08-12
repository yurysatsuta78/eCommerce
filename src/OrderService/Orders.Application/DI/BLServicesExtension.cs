using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Services.OrderItemsFactory;
using Orders.Application.Services.StockAvailabilityService;

namespace Orders.Application.DI
{
    public static class BLServicesExtension
    {
        public static IServiceCollection AddBLServices(this IServiceCollection services) 
        {
            services.AddScoped<IStockAvailabilityService, StockAvailabilityService>();
            services.AddScoped<IOrderItemsFactory, OrderItemsFactory>();

            return services;
        }
    }
}
