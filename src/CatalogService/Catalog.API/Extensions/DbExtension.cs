using Catalog.DAL.Data.Connection;

namespace Catalog.API.Extensions
{
    public static class DbExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("CATALOG_CONNECTION")
                ?? throw new InvalidOperationException($"Catalog connection string not found in configuration.");

            services.AddSingleton<IDbConnectionFactory>(new NpgConnectionFactory(connectionString));
            return services;
        }
    }
}
