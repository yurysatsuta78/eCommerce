using System.Data;

namespace Catalog.DAL.Data
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
