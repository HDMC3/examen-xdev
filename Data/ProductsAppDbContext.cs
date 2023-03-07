using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Data.Entities;

namespace ProductsApp.Data;

public class ProductsAppDbContext : DbContext {

    public DbSet<Product> Products { get; set; }

    public ProductsAppDbContext(DbContextOptions<ProductsAppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}