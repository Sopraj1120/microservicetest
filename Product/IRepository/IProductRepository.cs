using Product.Entity;

namespace Product.IRepository
{
    public interface IProductRepository
    {
        Task<Products> AddProduct(Products product);
        Task<Products> GetProductById(Guid id);
        Task<IEnumerable<Products>> GetAllProducts();
    }
}
