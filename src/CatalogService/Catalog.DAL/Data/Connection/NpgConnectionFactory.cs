using System.Data;
using Npgsql;

namespace Catalog.DAL.Data.Connection
{
    public class NpgConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public NpgConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
