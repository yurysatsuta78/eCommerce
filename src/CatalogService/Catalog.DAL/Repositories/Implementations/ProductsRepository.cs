using Catalog.DAL.Data;
using Catalog.DAL.Data.Connection;
using Catalog.DAL.Models;
using Catalog.DAL.QueryBuilders;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;
using Dapper;

namespace Catalog.DAL.Repositories.Implementations
{
    public class ProductsRepository : BaseRepository<ProductDb>, IProductsRepository
    {
        protected override string TableName => TablesMetadata.Products.Name;

        private readonly string productsAlias = TablesMetadata.Products.Alias;
        private readonly string categoriesAlias = TablesMetadata.Categories.Alias;
        private readonly string brandsAlias = TablesMetadata.Brands.Alias;

        public ProductsRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        public async Task<IEnumerable<ProductDb>> GetFilteredAsync(ProductQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new ProductQueryBuilder()
                .NameContains(filter.Name)
                .MinPrice(filter.MinPrice)
                .MaxPrice(filter.MaxPrice)
                .InStockOnly(filter.InStockOnly)
                .ByCategory(filter.CategoryId)
                .ByBrand(filter.BrandId);

            var (whereClause, parameters) = builder.Build(filter.PageNumber, filter.PageSize);

            var sql = $"""
            SELECT 
              {productsAlias}.id, {productsAlias}.name, {productsAlias}.description, {productsAlias}.price,
              {productsAlias}.in_stock AS {nameof(ProductDb.InStock)},
              {productsAlias}.reserved_stock AS {nameof(ProductDb.ReservedStock)},
              {productsAlias}.stock_capacity AS {nameof(ProductDb.StockCapacity)},
              {productsAlias}.brand_id AS {nameof(ProductDb.BrandId)},
              {productsAlias}.category_id AS {nameof(ProductDb.CategoryId)},
              {brandsAlias}.id AS Id, {brandsAlias}.name,
              {categoriesAlias}.id AS Id, {categoriesAlias}.name
            FROM {TableName} {productsAlias}
            INNER JOIN {TablesMetadata.Brands.Name} {brandsAlias} ON {productsAlias}.brand_id = {brandsAlias}.id
            INNER JOIN {TablesMetadata.Categories.Name} {categoriesAlias} ON {productsAlias}.category_id = {categoriesAlias}.id
            {whereClause}
            LIMIT @Limit OFFSET @Offset
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<ProductDb, BrandDb, CategoryDb, ProductDb>(
                new CommandDefinition(sql, parameters, cancellationToken: cancellationToken),
                map: (item, brand, category) =>
                {
                    item.Brand = brand;
                    item.Category = category;
                    return item;
                },
                splitOn: "Id,Id"
            );
        }

        public async Task<int> GetCountAsync(ProductQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new ProductQueryBuilder()
                .NameContains(filter.Name)
                .MinPrice(filter.MinPrice)
                .MaxPrice(filter.MaxPrice)
                .InStockOnly(filter.InStockOnly)
                .ByCategory(filter.CategoryId)
                .ByBrand(filter.BrandId);

            var (whereClause, parameters) = builder.Build();

            var sql = $"""
            SELECT COUNT(*)
            FROM {TableName} {productsAlias}
            INNER JOIN {TablesMetadata.Brands.Name} {brandsAlias} ON {productsAlias}.brand_id = {brandsAlias}.id
            INNER JOIN {TablesMetadata.Categories.Name} {categoriesAlias} ON {productsAlias}.category_id = {categoriesAlias}.id
            {whereClause}
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
        }

        public override async Task<ProductDb?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = $"""
            SELECT 
              {productsAlias}.id, {productsAlias}.name, {productsAlias}.description, {productsAlias}.price,
              {productsAlias}.in_stock AS {nameof(ProductDb.InStock)},
              {productsAlias}.reserved_stock AS {nameof(ProductDb.ReservedStock)},
              {productsAlias}.stock_capacity AS {nameof(ProductDb.StockCapacity)},
              {productsAlias}.brand_id AS {nameof(ProductDb.BrandId)},
              {productsAlias}.category_id AS {nameof(ProductDb.CategoryId)},
              {brandsAlias}.id AS Id, {brandsAlias}.name,
              {categoriesAlias}.id AS Id, {categoriesAlias}.name
            FROM {TableName} {productsAlias}
            INNER JOIN {TablesMetadata.Brands.Name} {brandsAlias} ON {productsAlias}.brand_id = {brandsAlias}.id
            INNER JOIN {TablesMetadata.Categories.Name} {categoriesAlias} ON {productsAlias}.category_id = {categoriesAlias}.id
            WHERE {productsAlias}.id = @{nameof(ProductDb.Id)}
            """;

            using var connection = _connectionFactory.CreateConnection();
            var result = await connection.QueryAsync<ProductDb, BrandDb, CategoryDb, ProductDb>(
                new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken),
                map: (item, brand, category) =>
                {
                    item.Brand = brand;
                    item.Category = category;
                    return item;
                },
                splitOn: "Id,Id"
            );

            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<ProductDb>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken)
        {
            if (ids == null || !ids.Any())
                return Enumerable.Empty<ProductDb>();

            var sql = $"""
            SELECT id, name, description, price,
              in_stock AS {nameof(ProductDb.InStock)},
              reserved_stock AS {nameof(ProductDb.ReservedStock)},
              stock_capacity AS {nameof(ProductDb.StockCapacity)}
            FROM {TableName}
            WHERE id = ANY(@Ids)
            """;

            using var connection = _connectionFactory.CreateConnection();
            var result = await connection.QueryAsync<ProductDb>(
                new CommandDefinition(sql, new { Ids = ids.ToArray() }, cancellationToken: cancellationToken)
            );

            return result;
        }

        public override async Task AddAsync(ProductDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            INSERT INTO {TableName} (id, name, description, price, in_stock, reserved_stock,
                stock_capacity, brand_id, category_id)
            VALUES (@{nameof(ProductDb.Id)}, @{nameof(ProductDb.Name)}, @{nameof(ProductDb.Description)}, 
                @{nameof(ProductDb.Price)}, @{nameof(ProductDb.InStock)}, @{nameof(ProductDb.ReservedStock)},
                @{nameof(ProductDb.StockCapacity)}, @{nameof(ProductDb.BrandId)},
                @{nameof(ProductDb.CategoryId)}
            )
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(
                new CommandDefinition(sql, entity, cancellationToken: cancellationToken)
            );
        }

        public override async Task UpdateAsync(ProductDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            UPDATE {TableName} SET
                name = @{nameof(ProductDb.Name)},
                description = @{nameof(ProductDb.Description)},
                price = @{nameof(ProductDb.Price)},
                in_stock = @{nameof(ProductDb.InStock)},
                reserved_stock = @{nameof(ProductDb.ReservedStock)},
                stock_capacity = @{nameof(ProductDb.StockCapacity)},
                brand_id = @{nameof(ProductDb.BrandId)},
                category_id = @{nameof(ProductDb.CategoryId)}
            WHERE id = @{nameof(ProductDb.Id)}
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(
                new CommandDefinition(sql, entity, cancellationToken: cancellationToken)
            );
        }
    }
}
