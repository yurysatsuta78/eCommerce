using Catalog.DAL.Data;
using Catalog.DAL.Models;
using Catalog.DAL.Repositories.Interfaces;
using Dapper;

namespace Catalog.DAL.Repositories.Implementations
{
    public class CatalogCategoryRepository : BaseRepository<CatalogCategoryDb>, ICatalogCategoryRepository
    {
        protected override string TableName => "catalog_category";

        public CatalogCategoryRepository(IDbConnectionFactory connectionFactory) : base(connectionFactory) { }

        public override async Task AddAsync(CatalogCategoryDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            INSERT INTO {TableName} (Id, Name)
            VALUES (@Id, @Name)
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }

        public override async Task UpdateAsync(CatalogCategoryDb entity, CancellationToken cancellationToken)
        {
            var sql = $"""
            UPDATE {TableName}
            SET Name = @Name
            WHERE Id = @Id
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, entity, cancellationToken: cancellationToken));
        }
    }
}
