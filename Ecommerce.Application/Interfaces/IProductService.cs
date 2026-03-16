using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();

    Task<ProductDto?> GetAsync(int id);

    Task CreateAsync(ProductDto dto);

    Task UpdateAsync(ProductDto dto);

    Task DeleteAsync(int id);
}