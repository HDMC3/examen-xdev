using System.Reflection;
using ProductsApp.Services.Files;
using ProductsApp.Services.Products.Handlers;
using ProductsApp.Services.Products.Queries;

namespace ProductsApp.Services;

public static class ServicesRegistration
{
    public static void AddAppServices(this IServiceCollection services) {
        services.AddScoped<GetProducts>();
        services.AddScoped<CreateProduct>();
        services.AddScoped<GetProductDetail>();
        services.AddScoped<GetProductToEdit>();
        services.AddScoped<EditProduct>();
        services.AddScoped<DeleteProduct>();
        services.AddScoped<GenerateProductsSpreadsheet>();
    }
}