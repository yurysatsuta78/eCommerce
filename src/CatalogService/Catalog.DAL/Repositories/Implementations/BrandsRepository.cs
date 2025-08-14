using Catalog.DAL.Data;
using Catalog.DAL.Data.Connection;
using Catalog.DAL.Models;
using Catalog.DAL.QueryBuilders;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;
using Dapper;

namespace Catalog.DAL.Repositories.Implementations
{
    public class BrandsRepository : BaseRepository<BrandDb>, IBrandsRepository
    {
        protected override string TableName => TablesMetadata.Brands.Name;

        public BrandsRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        public async Task<IEnumerable<BrandDb>> GetFilteredAsync(BrandQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new BrandQueryBuilder()
                .NameContains(filter.Name);

            var (whereClause, parameters) = builder.Build(filter.PageNumber, filter.PageSize);

            var sql = $"""
            SELECT id, name
            FROM {TableName}
            {whereClause}
            LIMIT @Limit OFFSET @Offset
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<BrandDb>(
                new CommandDefinition(sql, parameters, cancellationToken: cancellationToken)
            );
        }

        public async Task<int> GetCountAsync(BrandQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new BrandQueryBuilder()
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

        public override async Task AddAsync(BrandDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            INSERT INTO {TableName} (id, name)
            VALUES (@{nameof(BrandDb.Id)}, @{nameof(BrandDb.Name)})
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }

        public override async Task UpdateAsync(BrandDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            UPDATE {TableName}
            SET name = @{nameof(BrandDb.Name)}
            WHERE id = @{nameof(BrandDb.Id)}
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }
    }
}
