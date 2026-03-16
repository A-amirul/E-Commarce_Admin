using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs;

public class ProductDto
{
    public int ProductID { get; set; }

    [Required]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    public string? ProductImage { get; set; }

    public string? ProductDetails { get; set; }

    [Required]
    public int CategoryID { get; set; }

    public string? CategoryName { get; set; }
}