using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.DTOs;

public class CategoryDto
{
    public int CategoryID { get; set; }

    [Required]
    public string CategoryName { get; set; } = string.Empty;

    public string? Slug { get; set; }

    public string? Description { get; set; }

    public bool IsActive { get; set; }
}