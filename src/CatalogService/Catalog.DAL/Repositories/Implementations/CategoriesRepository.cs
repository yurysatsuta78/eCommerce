using Catalog.DAL.Data;
using Catalog.DAL.Data.Connection;
using Catalog.DAL.Models;
using Catalog.DAL.QueryBuilders;
using Catalog.DAL.QueryParams;
using Catalog.DAL.Repositories.Interfaces;
using Dapper;

namespace Catalog.DAL.Repositories.Implementations
{
    public class CategoriesRepository : BaseRepository<CategoryDb>, ICategoriesRepository
    {
        protected override string TableName => TablesMetadata.Categories.Name;

        public CategoriesRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        public async Task<IEnumerable<CategoryDb>> GetFilteredAsync(CategoryQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new CategoryQueryBuilder()
                .NameContains(filter.Name);

            var (whereClause, parameters) = builder.Build(filter.PageNumber, filter.PageSize);

            var sql = $"""
            SELECT id, name
            FROM {TableName}
            {whereClause}
            LIMIT @Limit OFFSET @Offset
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<CategoryDb>(
                new CommandDefinition(sql, parameters, cancellationToken: cancellationToken)
            );
        }

        public async Task<int> GetCountAsync(CategoryQueryParams filter, CancellationToken cancellationToken)
        {
            var builder = new CategoryQueryBuilder()
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

        public override async Task AddAsync(CategoryDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            INSERT INTO {TableName} (id, name)
            VALUES (@{nameof(CategoryDb.Id)}, @{nameof(CategoryDb.Name)})
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }

        public override async Task UpdateAsync(CategoryDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            UPDATE {TableName}
            SET name = @{nameof(CategoryDb.Name)}
            WHERE id = @{nameof(CategoryDb.Id)}
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }
    }
}
