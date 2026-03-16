using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Admin.Web.Models;

public class Product
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category? Category { get; set; }
}