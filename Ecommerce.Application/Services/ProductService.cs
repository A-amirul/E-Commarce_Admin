using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class ProductService : IProductService
{
    private readonly IRepository<Product> _repository;
    private readonly IRepository<Category> _categoryRepository;

    public ProductService(
        IRepository<Product> repository,
        IRepository<Category> categoryRepository)
    {
        _repository = repository; // ✅ FIXED
        _categoryRepository = categoryRepository;
    }

    // Get all products with CategoryName (optimized)
    public async Task<List<ProductDto>> GetAllAsync()
    {
        var products = await _repository.GetAllAsync();
        var categories = await _categoryRepository.GetAllAsync();

        // 🔥 O(1) lookup instead of FirstOrDefault every time
        var categoryDict = categories.ToDictionary(c => c.CategoryID, c => c.CategoryName);

        return products.Select(p => new ProductDto
        {
            ProductID = p.ProductID,
            ProductName = p.ProductName,
            Price = p.Price,
            ProductImage = p.ProductImage,
            ProductDetails = p.ProductDetails,
            CategoryID = p.CategoryID,
            CategoryName = categoryDict.ContainsKey(p.CategoryID)
                ? categoryDict[p.CategoryID]
                : "Unknown"
        }).ToList();
    }

    public async Task<ProductDto?> GetAsync(int id)
    {
        var p = await _repository.GetByIdAsync(id);
        if (p == null) return null;

        var category = await _categoryRepository.GetByIdAsync(p.CategoryID);

        return new ProductDto
        {
            ProductID = p.ProductID,
            ProductName = p.ProductName,
            Price = p.Price,
            ProductImage = p.ProductImage,
            ProductDetails = p.ProductDetails,
            CategoryID = p.CategoryID,
            CategoryName = category?.CategoryName ?? "Unknown"
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

        await _repository.AddAsync(product);
        await _repository.SaveAsync();
    }

    public async Task UpdateAsync(ProductDto dto)
    {
        var product = await _repository.GetByIdAsync(dto.ProductID);
        if (product == null) return;

        product.ProductName = dto.ProductName;
        product.Price = dto.Price;
        product.ProductImage = dto.ProductImage;
        product.ProductDetails = dto.ProductDetails;
        product.CategoryID = dto.CategoryID;

        _repository.Update(product);
        await _repository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var product = await _repository.GetByIdAsync(id);
        if (product == null) return;

        _repository.Delete(product);
        await _repository.SaveAsync();
    }
}