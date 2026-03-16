using Ecommerce.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Domain.Entities;

public class Category : BaseEntity
{
    [Key]
    public int CategoryID { get; set; }

    [Required]
    [MaxLength(150)]
    public string CategoryName { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? Slug { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Product> Products { get; set; } = new List<Product>();
}