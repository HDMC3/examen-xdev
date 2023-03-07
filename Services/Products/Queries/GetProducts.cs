using ProductsApp.Data;
using ProductsApp.Models;
using ProductsApp.Data.Entities;
using ProductsApp.Data.Extensions;

namespace ProductsApp.Services.Products.Queries;

public class GetProducts {
    private readonly ProductsAppDbContext _context;

    public GetProducts(ProductsAppDbContext context) {
        _context = context;
    }

    public async Task<DataCollection<Product>> Get(int page, int take) {
        var products = await _context.Products.GetPagedAsync(page, take);

        return products;
    }
}