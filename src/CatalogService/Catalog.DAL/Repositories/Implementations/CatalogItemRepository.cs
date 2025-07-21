using Catalog.DAL.Data;
using Catalog.DAL.Models;
using Catalog.DAL.Repositories.Interfaces;
using Dapper;

namespace Catalog.DAL.Repositories.Implementations
{
    public class CatalogItemRepository : BaseRepository<CatalogItemDb>, ICatalogItemRepository
    {
        protected override string TableName => "catalog_item";

        public CatalogItemRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        public override async Task<IEnumerable<CatalogItemDb>> GetAllAsync(CancellationToken cancellationToken)
        {
            var sql = $"""
            SELECT 
              ci.id, ci.name, ci.description, ci.price,
              ci.picture_file_name AS {nameof(CatalogItemDb.PictureFileName)},
              ci.available_stock AS {nameof(CatalogItemDb.AvailableStock)},
              ci.restock_threshold AS {nameof(CatalogItemDb.RestockThreshold)},
              ci.max_stock_threshold AS {nameof(CatalogItemDb.MaxStockThreshold)},
              ci.on_order AS {nameof(CatalogItemDb.OnOrder)},
              ci.catalog_brand_id AS {nameof(CatalogItemDb.CatalogBrandId)},
              ci.catalog_category_id AS {nameof(CatalogItemDb.CatalogCategoryId)},
              cb.id AS Id, cb.name,
              cc.id AS Id, cc.name
            FROM catalog_item ci
            LEFT JOIN catalog_brand cb ON ci.catalog_brand_id = cb.id
            LEFT JOIN catalog_category cc ON ci.catalog_category_id = cc.id
            """;

            using var connection = _connectionFactory.CreateConnection();
            var items = await connection.QueryAsync<CatalogItemDb, CatalogBrandDb, CatalogCategoryDb, CatalogItemDb>(
                new CommandDefinition(sql, cancellationToken: cancellationToken),
                map: (item, brand, category) => 
                {
                    item.CatalogBrand = brand;
                    item.CatalogCategory = category;
                    return item;
                },
                splitOn: "Id,Id"
            );

            return items;
        }

        public override async Task<CatalogItemDb?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = $"""
            SELECT 
              ci.id, ci.name, ci.description, ci.price,
              ci.picture_file_name AS {nameof(CatalogItemDb.PictureFileName)},
              ci.available_stock AS {nameof(CatalogItemDb.AvailableStock)},
              ci.restock_threshold AS {nameof(CatalogItemDb.RestockThreshold)},
              ci.max_stock_threshold AS {nameof(CatalogItemDb.MaxStockThreshold)},
              ci.on_order AS {nameof(CatalogItemDb.OnOrder)},
              ci.catalog_brand_id AS {nameof(CatalogItemDb.CatalogBrandId)},
              ci.catalog_category_id AS {nameof(CatalogItemDb.CatalogCategoryId)},
              cb.id AS Id, cb.name,
              cc.id AS Id, cc.name
            FROM catalog_item ci
            LEFT JOIN catalog_brand cb ON ci.catalog_brand_id = cb.id
            LEFT JOIN catalog_category cc ON ci.catalog_category_id = cc.id
            WHERE ci.id = @Id
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
            var sql = """
            INSERT INTO catalog_item (id, name, description, price, picture_file_name, available_stock, restock_threshold,
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
            var sql = """
            UPDATE catalog_item SET
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
