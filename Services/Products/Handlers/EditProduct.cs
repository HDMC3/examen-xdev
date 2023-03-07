using ProductsApp.Data;
using ProductsApp.Data.Entities;
using ProductsApp.Services.Products.DTOs;

namespace ProductsApp.Services.Products.Handlers;

public class EditProduct {
    private readonly ProductsAppDbContext _context;

    public EditProduct(ProductsAppDbContext context) {
        _context = context;
    }

    public async Task Handle(EditProductRequest request) {
        var product = await _context.Products.FindAsync(request.Id);

        if (product == null) {
            throw new Exception("El producto no existe");
        }

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.LastModified = DateTime.Now;

        await _context.SaveChangesAsync();
    }
}