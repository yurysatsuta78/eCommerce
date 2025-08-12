using Grpc.Contracts.ProtoBase;
using Microsoft.Extensions.DependencyInjection;
using Orders.Application.Services.Interfaces;
using Orders.Infrastructure.Services.Catalog;

namespace Orders.Infrastructure.DI
{
    public static class GrpcServicesExtension
    {
        public static IServiceCollection AddGrpcClients(this IServiceCollection services) 
        {
            var catalogServerUri = new Uri(Environment.GetEnvironmentVariable("CATALOG_GRPC_URL")
                ?? throw new InvalidOperationException($"Catalog gRPC server uri was not found in the environment."));

            services.AddGrpcClient<CatalogService.CatalogServiceClient>(options =>
                options.Address = catalogServerUri);

            services.AddScoped<ICatalogItemsInfoService, CatalogItemsInfoService>();

            return services;
        }
    }
}
