using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Value> Values { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
                .HasData
                (
                    new Value { Id = 1, Name = "Althea" },
                    new Value { Id = 2, Name = "Walter"}
                );

            builder.Entity<ProductCategory>()
                .HasKey(c => c.CategoryId);

            builder.Entity<Product>()
                .HasKey(x => x.ProdId);
            builder.Entity<Product>()
                .Property(p => p.ProdId).ValueGeneratedOnAdd();
        }
    }
}
