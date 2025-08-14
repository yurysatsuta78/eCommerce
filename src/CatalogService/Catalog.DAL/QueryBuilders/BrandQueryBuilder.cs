using Catalog.DAL.Data;
using Catalog.DAL.QueryBuilders.Base;

namespace Catalog.DAL.QueryBuilders
{
    public class BrandQueryBuilder : QueryBuilder
    {
        protected override string TableAlias => TablesMetadata.Brands.Alias;

        public BrandQueryBuilder NameContains(string? name)
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
