using Catalog.DAL.Data;
using Catalog.DAL.QueryBuilders.Base;

namespace Catalog.DAL.QueryBuilders
{
    public class ProductQueryBuilder : QueryBuilder
    {
        protected override string TableAlias => TablesMetadata.Products.Alias;

        public ProductQueryBuilder NameContains(string? name) 
        {
            if (name is not null) 
            {
                AppendCondition($"{TableAlias}.name ILIKE @Name");
                _params.Add("Name", $"%{name}%");
            }
            return this;
        }

        public ProductQueryBuilder MinPrice(decimal? minPrice) 
        {
            if (minPrice is not null) 
            {
                AppendCondition($"{TableAlias}.price >= @MinPrice");
                _params.Add("MinPrice", minPrice);
            }
            return this;
        }

        public ProductQueryBuilder MaxPrice(decimal? maxPrice)
        {
            if (maxPrice is not null)
            {
                AppendCondition($"{TableAlias}.price <= @MaxPrice");
                _params.Add("MaxPrice", maxPrice);
            }
            return this;
        }

        public ProductQueryBuilder InStockOnly(bool? inStockOnly)
        {
            if (inStockOnly == true)
            {
                AppendCondition($"{TableAlias}.available_stock > 0");
            }
            return this;
        }

        public ProductQueryBuilder ByBrand(Guid? brandId)
        {
            if (brandId is not null)
            {
                AppendCondition($"{TableAlias}.catalog_brand_id = @BrandId");
                _params.Add("BrandId", brandId);
            }
            return this;
        }

        public ProductQueryBuilder ByCategory(Guid? categoryId)
        {
            if (categoryId is not null)
            {
                AppendCondition($"{TableAlias}.catalog_category_id = @CategoryId");
                _params.Add("CategoryId", categoryId);
            }
            return this;
        }
    }
}
