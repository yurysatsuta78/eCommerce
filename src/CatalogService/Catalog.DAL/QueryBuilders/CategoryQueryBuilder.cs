using Catalog.DAL.Data;
using Catalog.DAL.QueryBuilders.Base;

namespace Catalog.DAL.QueryBuilders
{
    public class CategoryQueryBuilder : QueryBuilder
    {
        protected override string TableAlias => TablesMetadata.Categories.Alias;

        public CategoryQueryBuilder NameContains(string? name)
        {
            if (name is not null)
            {
                AppendCondition($"{TableAlias}.name ILIKE @Name");
                _params.Add("Name", $"%{name}%");
            }
            return this;
        }
    }
}
