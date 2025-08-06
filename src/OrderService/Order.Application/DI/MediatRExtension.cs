using Microsoft.Extensions.DependencyInjection;

namespace Order.Application.DI
{
    public static class MediatRExtension
    {
        public static IServiceCollection AddMediatR(this IServiceCollection services) 
        {
            services.AddMediatR(configuration => 
                configuration.RegisterServicesFromAssembly(typeof(MediatRExtension).Assembly));

            return services;
        }
    }
}
