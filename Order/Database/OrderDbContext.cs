using Microsoft.EntityFrameworkCore;
using Order.Entity;
using Product.Entity;


namespace Order.Database
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }
        public DbSet<Order.Entity.Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order.Entity.Order>()
                .Property(o => o.TotalPrice)
                .HasPrecision(18, 2); // 18 digits total, 2 decimal places

            modelBuilder.Entity<Products>()
                .Property(p => p.Price)
                .HasPrecision(18, 2); // 18 digits total, 2 decimal places
        }

    }
}
