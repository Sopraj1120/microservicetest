using Microsoft.EntityFrameworkCore;
using Product.Entity;

namespace Product.Database
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }
        public DbSet<Products> Products { get; set; }
    }

}
