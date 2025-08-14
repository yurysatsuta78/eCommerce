using Contracts.ProtoBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Services.Interfaces;
using Orders.Infrastructure.Services.Catalog;

namespace Orders.Infrastructure.DI
{
    public static class GrpcServicesExtension
    {
        public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration) 
        {
            var catalogServerUri = new Uri(configuration.GetValue<string>("CATALOG_GRPC_URL")
                ?? throw new InvalidOperationException($"Catalog gRPC server uri not found in configuration."));

            services.AddGrpcClient<CatalogService.CatalogServiceClient>(options =>
                options.Address = catalogServerUri);

            services.AddScoped<IProductsInfoService, ProductsInfoService>();

            return services;
        }
    }
}
