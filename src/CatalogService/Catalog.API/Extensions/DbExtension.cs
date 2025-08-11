using Catalog.DAL.Data.Connection;

namespace Catalog.API.Extensions
{
    public static class DbExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = Environment.GetEnvironmentVariable("CATALOG_CONNECTION")
                ?? throw new InvalidOperationException($"Catalog connection string was not found in the environment.");

            services.AddSingleton<IDbConnectionFactory>(new NpgConnectionFactory(connectionString));
            return services;
        }
    }
}
