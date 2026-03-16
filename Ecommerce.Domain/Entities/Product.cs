using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Domain.Entities;

public class Product : BaseEntity
{
    [Key]
    public int ProductID { get; set; }

    [Required, MaxLength(200)]
    public string ProductName { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    [MaxLength(500)]
    public string? ProductImage { get; set; }

    [MaxLength(2000)]
    public string? ProductDetails { get; set; }

    // Foreign Key
    [Required]
    public int CategoryID { get; set; }

    // Navigation Property
    [ForeignKey(nameof(CategoryID))]
    public Category? Category { get; set; }
}