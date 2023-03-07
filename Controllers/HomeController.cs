using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProductsApp.Data;
using ProductsApp.Models;
using ProductsApp.Services.Products.DTOs;
using ProductsApp.Services.Products.Handlers;
using ProductsApp.Services.Products.Queries;

namespace ProductsApp.Controllers;

public class HomeController : Controller
{
    private readonly GetProducts _getProducts;
    private readonly CreateProduct _createProduct;
    private readonly GetProductDetail _getProductById;
    private readonly GetProductToEdit _getProductToEdit;

    public HomeController(
        GetProducts getProducts, CreateProduct createProduct, GetProductDetail getProductById,
        GetProductToEdit getProductToEdit
    )
    {   
        _getProducts = getProducts;
        _createProduct = createProduct;
        _getProductById = getProductById;
        _getProductToEdit = getProductToEdit;
    }

    public async Task<IActionResult> Index(int page = 1, int take = 5)
    {
        if (page < 1) {
            page = 1;
        }

        var products = await _getProducts.Get(page, take);
        return View(products);
    }

    [Route("Details/{id}")]
    public async Task<IActionResult> ProductDetails(int id) {
        var model = await _getProductById.Get(id);
        return View(model);
    }

    public IActionResult CreateProduct() {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProductRequest product) {
        if (!ModelState.IsValid) {
            return RedirectToAction("Error");
        }

        await _createProduct.Handle(product);

        return RedirectToAction("Index");
    }

    [Route("Edit/{id}")]
    public async Task<IActionResult> EditProduct(int id) {
        var model = await _getProductToEdit.Get(id);
        return View(model);
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
