using Catalog.DAL.Data;
using Catalog.DAL.Data.Connection;
using Catalog.DAL.Models;
using Catalog.DAL.QueryBuilders;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;
using Dapper;

namespace Catalog.DAL.Repositories.Implementations
{
    public class CatalogBrandRepository : BaseRepository<CatalogBrandDb>, ICatalogBrandRepository
    {
        protected override string TableName => TablesMetadata.CatalogBrand.Name;

        public CatalogBrandRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        public async Task<IEnumerable<CatalogBrandDb>> GetPaginatedAsync(CatalogBrandQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new CatalogBrandQueryBuilder()
                .NameContains(filter.Name);

            var (whereClause, parameters) = builder.Build(filter.PageNumber, filter.PageSize);

            var sql = $"""
            SELECT id, name
            FROM {TableName}
            {whereClause}
            LIMIT @Limit OFFSET @Offset
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<CatalogBrandDb>(
                new CommandDefinition(sql, parameters, cancellationToken: cancellationToken)
            );
        }

        public async Task<int> GetCountAsync(CatalogBrandQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new CatalogBrandQueryBuilder()
                .NameContains(filter.Name);

            var (whereClause, parameters) = builder.Build();

            var sql = $"""
            SELECT COUNT(*)
            FROM {TableName}
            {whereClause}
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.ExecuteScalarAsync<int>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken));
        }

        public override async Task AddAsync(CatalogBrandDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            INSERT INTO {TableName} (id, name)
            VALUES (@{nameof(CatalogBrandDb.Id)}, @{nameof(CatalogBrandDb.Name)})
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }

        public override async Task UpdateAsync(CatalogBrandDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            UPDATE {TableName}
            SET name = @{nameof(CatalogBrandDb.Name)}
            WHERE id = @{nameof(CatalogBrandDb.Id)}
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }
    }
}
