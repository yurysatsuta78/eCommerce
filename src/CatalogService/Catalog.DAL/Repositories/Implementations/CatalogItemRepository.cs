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

        public async Task<IEnumerable<CatalogItemDb>> GetPaginatedAsync(CatalogItemQueryParams filter, CancellationToken cancellationToken)
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
              {itemAlias}.picture_file_name AS {nameof(CatalogItemDb.PictureFileName)},
              {itemAlias}.available_stock AS {nameof(CatalogItemDb.AvailableStock)},
              {itemAlias}.restock_threshold AS {nameof(CatalogItemDb.RestockThreshold)},
              {itemAlias}.max_stock_threshold AS {nameof(CatalogItemDb.MaxStockThreshold)},
              {itemAlias}.on_order AS {nameof(CatalogItemDb.OnOrder)},
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

        public override async Task<CatalogItemDb?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = $"""
            SELECT 
              {itemAlias}.id, {itemAlias}.name, {itemAlias}.description, {itemAlias}.price,
              {itemAlias}.picture_file_name AS {nameof(CatalogItemDb.PictureFileName)},
              {itemAlias}.available_stock AS {nameof(CatalogItemDb.AvailableStock)},
              {itemAlias}.restock_threshold AS {nameof(CatalogItemDb.RestockThreshold)},
              {itemAlias}.max_stock_threshold AS {nameof(CatalogItemDb.MaxStockThreshold)},
              {itemAlias}.on_order AS {nameof(CatalogItemDb.OnOrder)},
              {itemAlias}.catalog_brand_id AS {nameof(CatalogItemDb.CatalogBrandId)},
              {itemAlias}.catalog_category_id AS {nameof(CatalogItemDb.CatalogCategoryId)},
              {brandAlias}.id AS Id, {brandAlias}.name,
              {categoryAlias}.id AS Id, {categoryAlias}.name
            FROM {TableName} {itemAlias}
            INNER JOIN {TablesMetadata.CatalogBrand.Name} {brandAlias} ON {itemAlias}.catalog_brand_id = {brandAlias}.id
            INNER JOIN {TablesMetadata.CatalogCategory.Name} {categoryAlias} ON {itemAlias}.catalog_category_id = {categoryAlias}.id
            WHERE {itemAlias}.id = @Id
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
            INSERT INTO {TableName} (id, name, description, price, picture_file_name, available_stock, restock_threshold,
                max_stock_threshold, on_order, catalog_brand_id, catalog_category_id)
            VALUES (@Id, @Name, @Description, @Price, @PictureFileName, @AvailableStock, @RestockThreshold,
                @MaxStockThreshold, @OnOrder, @CatalogBrandId, @CatalogCategoryId)
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
                name = @Name,
                description = @Description,
                price = @Price,
                picture_file_name = @PictureFileName,
                available_stock = @AvailableStock,
                restock_threshold = @RestockThreshold,
                max_stock_threshold = @MaxStockThreshold,
                on_order = @OnOrder,
                catalog_brand_id = @CatalogBrandId,
                catalog_category_id = @CatalogCategoryId
            WHERE id = @Id
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(
                new CommandDefinition(sql, entity, cancellationToken: cancellationToken)
            );
        }
    }
}
