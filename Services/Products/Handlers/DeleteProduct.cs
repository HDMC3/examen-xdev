using ProductsApp.Data;

namespace ProductsApp.Services.Products.Handlers;

public class DeleteProduct {
    private readonly ProductsAppDbContext _context;
    public DeleteProduct(ProductsAppDbContext context) {
        _context = context;
    }

    public async Task Handle(int id) {
        var product = await _context.Products.FindAsync(id);

        if (product == null) {
            throw new Exception("El producto no existe");
        }

        _context.Remove(product);

        await _context.SaveChangesAsync();
    }
}