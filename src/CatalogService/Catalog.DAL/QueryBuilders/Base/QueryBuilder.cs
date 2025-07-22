using System.Text;
using Dapper;

namespace Catalog.DAL.QueryBuilders.Base
{
    public abstract class QueryBuilder
    {
        protected readonly StringBuilder _whereClause = new();
        protected readonly Dictionary<string, object> _params = new();
        protected abstract string TableAlias { get; }

        protected void AppendCondition(string condition)
        {
            if (_whereClause.Length > 0)
                _whereClause.Append(" AND ");

            _whereClause.Append(condition);
        }

        public (string WhereClause, DynamicParameters Parameters) Build(int? pageNumber = null, int? pageSize = null)
        {
            var clause = _whereClause.Length > 0 ? $"WHERE {_whereClause}" : string.Empty;
            var parameters = new DynamicParameters(_params);

            if (pageNumber is not null && pageSize is not null)
            {
                parameters.Add("Offset", (pageNumber - 1) * pageSize);
                parameters.Add("Limit", pageSize);
            }

            return (clause, parameters);
        }
    }
}
