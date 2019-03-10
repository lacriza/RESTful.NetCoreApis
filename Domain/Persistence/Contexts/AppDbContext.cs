using Microsoft.EntityFrameworkCore;
using SupermarketApiRest.Domain.Models;

namespace SupermarketApiRest.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().ToTable("Categories");
            builder.Entity<Category>().HasKey(key => key.Id);
            builder.Entity<Category>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(30);
            builder.Entity<Category>()
                .HasMany(p => p.Producs)
                .WithOne(p => p.Category)
                .HasForeignKey(fkey => fkey.CategoryId);

            builder.Entity<Category>().HasData(
                new Category {Id = 100, Name = "Fruits and Vegetables"}, 
                new Category {Id = 101, Name = "Dairy"});

            builder.Entity<Product>().ToTable("Products");
            builder.Entity<Product>().HasKey(key => key.Id);
            builder.Entity<Product>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Product>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Product>().Property(p => p.QuantityInPackage).IsRequired();
            builder.Entity<Product>().Property(p => p.UnitOfMeasurement).IsRequired();
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}