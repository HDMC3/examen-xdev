using System.Reflection;
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
    }
}