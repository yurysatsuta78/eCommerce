using Catalog.DAL.Data;
using Catalog.DAL.Data.Connection;
using Catalog.DAL.Models;
using Catalog.DAL.QueryBuilders;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;
using Dapper;

namespace Catalog.DAL.Repositories.Implementations
{
    public class CatalogItemRepository : BaseRepository<CatalogItemDb>, ICatalogItemRepository
    {
        protected override string TableName => TablesMetadata.CatalogItem.Name;

        private readonly string itemAlias = TablesMetadata.CatalogItem.Alias;
        private readonly string categoryAlias = TablesMetadata.CatalogCategory.Alias;
        private readonly string brandAlias = TablesMetadata.CatalogBrand.Alias;

        public CatalogItemRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        public async Task<IEnumerable<CatalogItemDb>> GetFilteredAsync(CatalogItemQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new CatalogItemQueryBuilder()
                .NameContains(filter.Name)
                .MinPrice(filter.MinPrice)
                .MaxPrice(filter.MaxPrice)
                .InStockOnly(filter.InStockOnly)
                .ByCategory(filter.CategoryId)
                .ByBrand(filter.BrandId);

            var (whereClause, parameters) = builder.Build(filter.PageNumber, filter.PageSize);

            var sql = $"""
            SELECT 
              {itemAlias}.id, {itemAlias}.name, {itemAlias}.description, {itemAlias}.price,
              {itemAlias}.available_stock AS {nameof(CatalogItemDb.AvailableStock)},
              {itemAlias}.restock_threshold AS {nameof(CatalogItemDb.RestockThreshold)},
              {itemAlias}.max_stock_threshold AS {nameof(CatalogItemDb.MaxStockThreshold)},
              {itemAlias}.catalog_brand_id AS {nameof(CatalogItemDb.CatalogBrandId)},
              {itemAlias}.catalog_category_id AS {nameof(CatalogItemDb.CatalogCategoryId)},
              {brandAlias}.id AS Id, {brandAlias}.name,
              {categoryAlias}.id AS Id, {categoryAlias}.name
            FROM {TableName} {itemAlias}
            INNER JOIN {TablesMetadata.CatalogBrand.Name} {brandAlias} ON {itemAlias}.catalog_brand_id = {brandAlias}.id
            INNER JOIN {TablesMetadata.CatalogCategory.Name} {categoryAlias} ON {itemAlias}.catalog_category_id = {categoryAlias}.id
            {whereClause}
            LIMIT @Limit OFFSET @Offset
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<CatalogItemDb, CatalogBrandDb, CatalogCategoryDb, CatalogItemDb>(
                new CommandDefinition(sql, parameters, cancellationToken: cancellationToken),
                map: (item, brand, category) =>
                {
                    item.CatalogBrand = brand;
                    item.CatalogCategory = category;
                    return item;
                },
                splitOn: "Id,Id"
            );
        }

        public async Task<int> GetCountAsync(CatalogItemQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new CatalogItemQueryBuilder()
                .NameContains(filter.Name)
                .MinPrice(filter.MinPrice)
                .MaxPrice(filter.MaxPrice)
                .InStockOnly(filter.InStockOnly)
                .ByCategory(filter.CategoryId)
                .ByBrand(filter.BrandId);

            var (whereClause, parameters) = builder.Build();

            var sql = $"""
            SELECT COUNT(*)
            FROM {TableName} {itemAlias}
            INNER JOIN {TablesMetadata.CatalogBrand.Name} {brandAlias} ON {itemAlias}.catalog_brand_id = {brandAlias}.id
            INNER JOIN {TablesMetadata.CatalogCategory.Name} {categoryAlias} ON {itemAlias}.catalog_category_id = {categoryAlias}.id
            {whereClause}
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
        }

        public override async Task<CatalogItemDb?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = $"""
            SELECT 
              {itemAlias}.id, {itemAlias}.name, {itemAlias}.description, {itemAlias}.price,
              {itemAlias}.available_stock AS {nameof(CatalogItemDb.AvailableStock)},
              {itemAlias}.restock_threshold AS {nameof(CatalogItemDb.RestockThreshold)},
              {itemAlias}.max_stock_threshold AS {nameof(CatalogItemDb.MaxStockThreshold)},
              {itemAlias}.catalog_brand_id AS {nameof(CatalogItemDb.CatalogBrandId)},
              {itemAlias}.catalog_category_id AS {nameof(CatalogItemDb.CatalogCategoryId)},
              {brandAlias}.id AS Id, {brandAlias}.name,
              {categoryAlias}.id AS Id, {categoryAlias}.name
            FROM {TableName} {itemAlias}
            INNER JOIN {TablesMetadata.CatalogBrand.Name} {brandAlias} ON {itemAlias}.catalog_brand_id = {brandAlias}.id
            INNER JOIN {TablesMetadata.CatalogCategory.Name} {categoryAlias} ON {itemAlias}.catalog_category_id = {categoryAlias}.id
            WHERE {itemAlias}.id = @{nameof(CatalogItemDb.Id)}
            """;

            using var connection = _connectionFactory.CreateConnection();
            var result = await connection.QueryAsync<CatalogItemDb, CatalogBrandDb, CatalogCategoryDb, CatalogItemDb>(
                new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken),
                map: (item, brand, category) =>
                {
                    item.CatalogBrand = brand;
                    item.CatalogCategory = category;
                    return item;
                },
                splitOn: "Id,Id"
            );

            return result.FirstOrDefault();
        }

        public override async Task AddAsync(CatalogItemDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            INSERT INTO {TableName} (id, name, description, price, available_stock, restock_threshold,
                max_stock_threshold, catalog_brand_id, catalog_category_id)
            VALUES (@{nameof(CatalogItemDb.Id)}, @{nameof(CatalogItemDb.Name)}, @{nameof(CatalogItemDb.Description)}, 
                @{nameof(CatalogItemDb.Price)}, @{nameof(CatalogItemDb.AvailableStock)}, @{nameof(CatalogItemDb.RestockThreshold)},
                @{nameof(CatalogItemDb.MaxStockThreshold)}, @{nameof(CatalogItemDb.CatalogBrandId)}, @{nameof(CatalogItemDb.CatalogCategoryId)}
            )
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(
                new CommandDefinition(sql, entity, cancellationToken: cancellationToken)
            );
        }

        public override async Task UpdateAsync(CatalogItemDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            UPDATE {TableName} SET
                name = @{nameof(CatalogItemDb.Name)},
                description = @{nameof(CatalogItemDb.Description)},
                price = @{nameof(CatalogItemDb.Price)},
                available_stock = @{nameof(CatalogItemDb.AvailableStock)},
                restock_threshold = @{nameof(CatalogItemDb.RestockThreshold)},
                max_stock_threshold = @{nameof(CatalogItemDb.MaxStockThreshold)},
                catalog_brand_id = @{nameof(CatalogItemDb.CatalogBrandId)},
                catalog_category_id = @{nameof(CatalogItemDb.CatalogCategoryId)}
            WHERE id = @{nameof(CatalogItemDb.Id)}
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(
                new CommandDefinition(sql, entity, cancellationToken: cancellationToken)
            );
        }
    }
}
