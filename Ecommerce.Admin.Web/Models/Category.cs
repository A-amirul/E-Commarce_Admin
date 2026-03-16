using Ecommerce.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Admin.Web.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public ICollection<Product>? Products { get; set; }
}