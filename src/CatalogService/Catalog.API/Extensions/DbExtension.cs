using Catalog.BLL.Validators.CatalogItem;
using Catalog.BLL.MappingProfiles.CatalogItemMappingProfiles;
using Catalog.BLL.Services.Implementations;
using Catalog.BLL.Services.Interfaces;
using Catalog.DAL.Data.Connection;
using Catalog.DAL.Repositories.Implementations;
using Catalog.DAL.Repositories.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace Catalog.API.Extensions
{
    public static class DbExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) 
        {
            const string connectionName = "CatalogConnection";

            var connectionString = configuration.GetConnectionString(connectionName)
                ?? throw new InvalidOperationException($"Connection string '{connectionName}' was not found in the configuration.");

            services.AddSingleton<IDbConnectionFactory>(new NpgConnectionFactory(connectionString));
            return services;
        }
    }
}
