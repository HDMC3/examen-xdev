using System.ComponentModel.DataAnnotations;

namespace ProductsApp.Services.Products.DTOs;

public class CreateProductRequest {
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public float Price { get; set; }
}