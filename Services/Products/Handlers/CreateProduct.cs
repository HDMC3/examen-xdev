using ProductsApp.Data;
using ProductsApp.Data.Entities;
using ProductsApp.Services.Products.DTOs;

namespace ProductsApp.Services.Products.Handlers;

public class CreateProduct {
    private readonly ProductsAppDbContext _context;

    public CreateProduct(ProductsAppDbContext context) {
        _context = context;
    }

    public async Task Handle(CreateProductRequest request) {
        var newProduct = new Product {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Created = DateTime.Now,
            LastModified = DateTime.Now
        };

        await _context.Products.AddAsync(newProduct);

        await _context.SaveChangesAsync();
    }
}