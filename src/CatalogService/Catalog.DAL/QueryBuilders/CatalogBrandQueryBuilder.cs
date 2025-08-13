using Catalog.DAL.Data;
using Catalog.DAL.QueryBuilders.Base;

namespace Catalog.DAL.QueryBuilders
{
    public class CatalogBrandQueryBuilder : QueryBuilder
    {
        protected override string TableAlias => TablesMetadata.CatalogBrand.Alias;

        public CatalogBrandQueryBuilder NameContains(string? name)
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
