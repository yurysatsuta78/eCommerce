using Catalog.BLL.MappingProfiles.CatalogItemMappingProfiles;
using Catalog.DAL.Data.Connection;
using Catalog.DAL.Repositories.Implementations;
using Catalog.DAL.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) 
        {
            const string connectionName = "CatalogConnection";

            var connectionString = configuration.GetConnectionString(connectionName)
                ?? throw new InvalidOperationException($"Строка подключения '{connectionName}' не найдена в конфигурации.");

            services.AddSingleton<IDbConnectionFactory>(new NpgConnectionFactory(connectionString));
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services) 
        {
            services.AddScoped<ICatalogItemRepository, CatalogItemRepository>();
            services.AddScoped<ICatalogBrandRepository, CatalogBrandRepository>();
            services.AddScoped<ICatalogCategoryRepository, CatalogCategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddAutomapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(assembly => assembly.AddMaps(typeof(CatalogItemProfile).Assembly));

            return services;
        }
    }
}
