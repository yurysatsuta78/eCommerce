using Catalog.DAL.Data;
using Catalog.DAL.Data.Connection;
using Catalog.DAL.Models;
using Catalog.DAL.QueryBuilders;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;
using Dapper;

namespace Catalog.DAL.Repositories.Implementations
{
    public class CatalogCategoryRepository : BaseRepository<CatalogCategoryDb>, ICatalogCategoryRepository
    {
        protected override string TableName => TablesMetadata.CatalogCategory.Name;

        public CatalogCategoryRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        public async Task<IEnumerable<CatalogCategoryDb>> GetFilteredAsync(CatalogCategoryQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new CatalogCategoryQueryBuilder()
                .NameContains(filter.Name);

            var (whereClause, parameters) = builder.Build(filter.PageNumber, filter.PageSize);

            var sql = $"""
            SELECT id, name
            FROM {TableName}
            {whereClause}
            LIMIT @Limit OFFSET @Offset
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<CatalogCategoryDb>(
                new CommandDefinition(sql, parameters, cancellationToken: cancellationToken)
            );
        }

        public async Task<int> GetCountAsync(CatalogCategoryQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new CatalogCategoryQueryBuilder()
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

        public override async Task AddAsync(CatalogCategoryDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            INSERT INTO {TableName} (id, name)
            VALUES (@{nameof(CatalogCategoryDb.Id)}, @{nameof(CatalogCategoryDb.Name)})
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }

        public override async Task UpdateAsync(CatalogCategoryDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            UPDATE {TableName}
            SET name = @{nameof(CatalogCategoryDb.Name)}
            WHERE id = @{nameof(CatalogCategoryDb.Id)}
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }
    }
}
