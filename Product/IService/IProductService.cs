using Product.Dtos.RequestDtos;
using Product.Dtos.ResponceDtos;

namespace Product.IService
{
    public interface IProductService
    {
        Task<ProductResponceDtos> AddProducts(ProductRequestDtos productRequestDtos);
        Task<ProductResponceDtos> GetProductById(Guid id);
        Task<IEnumerable<ProductResponceDtos>> GetAllProducts();
    }
}
