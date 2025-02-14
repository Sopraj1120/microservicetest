using Mapster;
using Microsoft.OpenApi.Models;
using Product.Dtos.RequestDtos;
using Product.Dtos.ResponceDtos;
using Product.Entity;
using Product.IRepository;
using Product.IService;

namespace Product.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductResponceDtos> AddProducts(ProductRequestDtos productRequestDtos)
        {
            var product = productRequestDtos.Adapt<Products>();

            var data = await _productRepository.AddProduct(product).ConfigureAwait(false);

            var res = data.Adapt<ProductResponceDtos>();
            return res;
        }

        public async Task<ProductResponceDtos> GetProductById(Guid id)
        {
            var data = await _productRepository.GetProductById(id).ConfigureAwait(false)
                ?? throw new KeyNotFoundException("Product Not Found!");
            var res = data.Adapt<ProductResponceDtos>();
            return res;
        }

        public async Task<IEnumerable<ProductResponceDtos>> GetAllProducts()
        {
            var data = await _productRepository.GetAllProducts().ConfigureAwait(false);
            var res = data.Adapt<IEnumerable<ProductResponceDtos>>();
            return res;
        }
    }
}
