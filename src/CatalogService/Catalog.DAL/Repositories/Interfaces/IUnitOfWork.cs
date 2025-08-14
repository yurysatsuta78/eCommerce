namespace Catalog.DAL.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IBrandsRepository BrandsRepository { get; }
        ICategoriesRepository CategoriesRepository { get; }
        IProductsRepository ProductsRepository { get; }
    }
}
