using Catalog.BLL.DtoValidators.CatalogItem;
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
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) 
        {
            const string connectionName = "CatalogConnection";

            var connectionString = configuration.GetConnectionString(connectionName)
                ?? throw new InvalidOperationException($"Connection string '{connectionName}' was not found in the configuration.");

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

        public static IServiceCollection AddBLLServices(this IServiceCollection services) 
        {
            services.AddScoped<ICatalogItemService, CatalogItemService>();
            services.AddScoped<ICatalogBrandService, CatalogBrandService>();
            services.AddScoped<ICatalogCategoryService, CatalogCategoryService>();

            return services;
        }

        public static IServiceCollection AddAutomapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(assembly => assembly.AddMaps(typeof(CatalogItemProfile).Assembly));

            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<CreateCatalogItemDtoValidator>();

            return services;
        }
    }
}
