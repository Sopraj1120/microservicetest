using Microsoft.EntityFrameworkCore;
using Product.Database;
using Product.Entity;
using Product.IRepository;

namespace Product.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<Products> AddProduct(Products product)
        {
            var data = await _context.Products.AddAsync(product).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return data.Entity;
        }

        public async Task<Products> GetProductById(Guid id)
        {
            var data = await _context.Products.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return data;
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var data = await _context.Products.ToListAsync().ConfigureAwait(false);
            return data;
        }
    }
}
