namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        ICatalogBrandRepository CatalogBrandRepository { get; }
        ICatalogCategoryRepository CatalogCategoryRepository { get; }
        ICatalogItemRepository CatalogItemRepository { get; }
    }
}
