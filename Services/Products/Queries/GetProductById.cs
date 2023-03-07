using ProductsApp.Data;
using ProductsApp.Data.Entities;
using ProductsApp.Models;

namespace ProductsApp.Services.Products.Queries;

public class GetProductById {
    private readonly ProductsAppDbContext _context;

    public GetProductById(ProductsAppDbContext context) {
        _context = context;
    }

    public async Task<ProductDetailViewModel> Get(int id) {
        var product = await _context.Products.FindAsync(id);

        if (product == null) {
            throw new Exception("Producto no encontrado");
        }

        var formatedPrice = string.Format("{0:0.##}", product.Price);

        var productDetailModel = new ProductDetailViewModel {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = formatedPrice.EndsWith("00") ? ((int)product.Price).ToString() : formatedPrice,
            Created = product.Created.ToString("dd/MM/yyyy")
        };

        return productDetailModel;
    } 
}