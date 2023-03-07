using ProductsApp.Data;
using ProductsApp.Models;

namespace ProductsApp.Services.Products.Queries;

public class GetProductToEdit {
    private readonly ProductsAppDbContext _context;

    public GetProductToEdit(ProductsAppDbContext context) {
        _context = context;
    }

    public async Task<EditProductViewModal> Get(int id) {
        var product = await _context.Products.FindAsync(id);

        if (product == null) {
            throw new Exception("Producto no encontrado");
        }

        var productDetailModel = new EditProductViewModal {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price
        };

        return productDetailModel;
    } 
}