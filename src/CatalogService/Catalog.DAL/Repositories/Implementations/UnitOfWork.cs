using Catalog.DAL.Repositories.Interfaces;

namespace Catalog.DAL.Repositories.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBrandsRepository BrandsRepository { get; }
        public ICategoriesRepository CategoriesRepository { get; }
        public IProductsRepository ProductsRepository { get; }

        public UnitOfWork(IBrandsRepository catalogBrandRepository, ICategoriesRepository catalogCategoryRepository,
            IProductsRepository catalogItemRepository)
        {
            BrandsRepository = catalogBrandRepository;
            CategoriesRepository = catalogCategoryRepository;
            ProductsRepository = catalogItemRepository;
        }
    }
}
