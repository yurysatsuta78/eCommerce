using Payment.BLL.MappingProfiles.ReceiptProfiles;

namespace Payment.API.Extensions
{
    public static class AutomapperExtension
    {
        public static IServiceCollection AddMapper(this IServiceCollection services) 
        {
            services.AddAutoMapper(assembly => assembly.AddMaps(typeof(ReceiptProfile).Assembly));

            return services;
        }
    }
}
