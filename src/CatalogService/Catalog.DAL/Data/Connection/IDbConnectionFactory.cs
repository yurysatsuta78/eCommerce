using System.Data;

namespace Catalog.DAL.Data.Connection
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
