using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Data;
using ProductsApp.Models;
using ProductsApp.Services.Products.Queries;

namespace ProductsApp.Controllers;

public class HomeController : Controller
{
    private readonly GetProducts _getProducts;

    public HomeController(GetProducts getProducts)
    {   
        _getProducts = getProducts;
    }

    public async Task<IActionResult> Index(int page, int take = 10)
    {
        if (page < 1) {
            page = 1;
        }
        
        var products = await _getProducts.Get(page, take);
        return View(products);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
