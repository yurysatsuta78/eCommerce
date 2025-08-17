using Payment.BLL.Services.Implementations;
using Payment.BLL.Services.Interfaces;

namespace Payment.API.Extensions
{
    public static class BLLServicesExtension
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services) 
        {
            services.AddScoped<IReceiptService, ReceiptService>();

            return services;
        }
    }
}
