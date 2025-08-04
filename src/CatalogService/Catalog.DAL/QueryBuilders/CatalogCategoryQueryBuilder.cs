using Catalog.DAL.Data;
using Catalog.DAL.QueryBuilders.Base;

namespace Catalog.DAL.QueryBuilders
{
    public class CatalogCategoryQueryBuilder : QueryBuilder
    {
        protected override string TableAlias => TablesMetadata.CatalogCategory.Alias;

        public CatalogCategoryQueryBuilder NameContains(string? name)
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
