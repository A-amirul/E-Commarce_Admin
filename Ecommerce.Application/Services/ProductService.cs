using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class ProductService(IRepository<Product> repository) : IProductService
{
    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await repository.GetAllAsync();

        return products.Select(p => new ProductDto
        {
            ProductID = p.ProductID,
            ProductName = p.ProductName,
            Price = p.Price,
            ProductImage = p.ProductImage,
            ProductDetails = p.ProductDetails,
            CategoryID = p.CategoryID,
            CategoryName = p.Category != null ? p.Category.CategoryName : ""
        }).ToList();
    }

    public async Task<ProductDto?> GetAsync(int id)
    {
        var p = await repository.GetByIdAsync(id);

        if (p == null) return null;

        return new ProductDto
        {
            ProductID = p.ProductID,
            ProductName = p.ProductName,
            Price = p.Price,
            ProductImage = p.ProductImage,
            ProductDetails = p.ProductDetails,
            CategoryID = p.CategoryID
        };
    }

    public async Task CreateAsync(ProductDto dto)
    {
        var product = new Product
        {
            ProductName = dto.ProductName,
            Price = dto.Price,
            ProductImage = dto.ProductImage,
            ProductDetails = dto.ProductDetails,
            CategoryID = dto.CategoryID
        };

        await repository.AddAsync(product);
        await repository.SaveAsync();
    }

    public async Task UpdateAsync(ProductDto dto)
    {
        var product = await repository.GetByIdAsync(dto.ProductID);

        if (product == null) return;

        product.ProductName = dto.ProductName;
        product.Price = dto.Price;
        product.ProductImage = dto.ProductImage;
        product.ProductDetails = dto.ProductDetails;
        product.CategoryID = dto.CategoryID;

        repository.Update(product);

        await repository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await repository.GetByIdAsync(id);

        if (product == null) return;

        repository.Delete(product);

        await repository.SaveAsync();
    }
}