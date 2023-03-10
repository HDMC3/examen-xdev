using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Models;
using ProductsApp.Services.Files;
using ProductsApp.Services.Products.DTOs;
using ProductsApp.Services.Products.Handlers;
using ProductsApp.Services.Products.Queries;

namespace ProductsApp.Controllers;

public class ProductsController : Controller
{
    private readonly GetProducts _getProducts;
    private readonly CreateProduct _createProduct;
    private readonly GetProductDetail _getProductById;
    private readonly GetProductToEdit _getProductToEdit;
    private readonly EditProduct _editProduct;
    private readonly DeleteProduct _deleteProduct;
    private readonly GenerateProductsSpreadsheet _generateProductsSpreadsheet;

    public ProductsController(
        GetProducts getProducts, CreateProduct createProduct, GetProductDetail getProductById,
        GetProductToEdit getProductToEdit, EditProduct editProduct, DeleteProduct deleteProduct,
        GenerateProductsSpreadsheet generateProductsSpreadsheet
    )
    {   
        _getProducts = getProducts;
        _createProduct = createProduct;
        _getProductById = getProductById;
        _getProductToEdit = getProductToEdit;
        _editProduct = editProduct;
        _deleteProduct = deleteProduct;
        _generateProductsSpreadsheet = generateProductsSpreadsheet;
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
    [ValidateAntiForgeryToken]
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditProductRequest product) {
        if (!ModelState.IsValid) {
            return RedirectToAction("Error");
        }

        await _editProduct.Handle(product);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id) {
        await _deleteProduct.Handle(id);

        return RedirectToAction("Index");
    }

    public async Task<FileResult> GenerateSpreadsheet() {
        var xlWorkBook = await _generateProductsSpreadsheet.Generate();

        using var stream = new MemoryStream();

        xlWorkBook.SaveAs(stream);
        return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "listado-productos.xlsx");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
