using Catalog.DAL.Data;
using Catalog.DAL.Repositories.Interfaces;
using Dapper;

namespace Catalog.DAL.Repositories.Implementations
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        protected readonly IDbConnectionFactory _connectionFactory;
        protected abstract string TableName { get; }

        protected BaseRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        //Переопределить для запросов со связанными сущностями
        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            var sql = $"""
            SELECT * FROM {TableName}
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryAsync<T>(
                new CommandDefinition(sql, cancellationToken: cancellationToken));
        }

        //Переопределить для запросов со связанными сущностями
        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var sql = $"""
            SELECT * FROM {TableName}
            WHERE Id = @Id
            """;

            using var connection = _connectionFactory.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(
                new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken));
        }

        //Реализовать в наследниках
        public abstract Task AddAsync(T entity, CancellationToken cancellationToken);

        //Реализовать в наследниках
        public abstract Task UpdateAsync(T entity, CancellationToken cancellationToken);

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken) 
        {
            var sql = $"""
            DELETE FROM {TableName}
            WHERE Id = @Id
            """;

            using var connection = _connectionFactory.CreateConnection();
            await connection.ExecuteAsync(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken));
        }
    }
}
