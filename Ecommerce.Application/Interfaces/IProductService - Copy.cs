using Ecommerce.Application.DTOs;

namespace Ecommerce.Application.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();

    Task<CategoryDto?> GetAsync(int id);

    Task CreateAsync(CategoryDto dto);

    Task UpdateAsync(CategoryDto dto);

    Task DeleteAsync(int id);
}