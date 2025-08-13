using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICatalogBrandRepository CatalogBrandRepository { get; }
        public ICatalogCategoryRepository CatalogCategoryRepository { get; }
        public ICatalogItemRepository CatalogItemRepository { get; }

        public UnitOfWork(ICatalogBrandRepository catalogBrandRepository, ICatalogCategoryRepository catalogCategoryRepository,
            ICatalogItemRepository catalogItemRepository)
        {
            CatalogBrandRepository = catalogBrandRepository;
            CatalogCategoryRepository = catalogCategoryRepository;
            CatalogItemRepository = catalogItemRepository;
        }
    }
}
