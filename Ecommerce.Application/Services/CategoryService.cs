using Ecommerce.Application.DTOs;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class CategoryService(IRepository<Category> repository) : ICategoryService
{

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var data = await repository.GetAllAsync();

        return data.Select(c => new CategoryDto
        {
            CategoryID = c.CategoryID,
            CategoryName = c.CategoryName,
            Slug = c.Slug,
            Description = c.Description,
            IsActive = c.IsActive
        }).ToList();
    }

    public async Task<CategoryDto?> GetAsync(int id)
    {
        var c = await repository.GetByIdAsync(id);

        if (c == null) return null;

        return new CategoryDto
        {
            CategoryID = c.CategoryID,
            CategoryName = c.CategoryName,
            Slug = c.Slug,
            Description = c.Description,
            IsActive = c.IsActive
        };
    }

    public async Task CreateAsync(CategoryDto dto)
    {
        var category = new Category
        {
            CategoryName = dto.CategoryName,
            Slug = dto.Slug,
            Description = dto.Description,
            IsActive = dto.IsActive
        };

        await repository.AddAsync(category);
        await repository.SaveAsync();
    }

    public async Task UpdateAsync(CategoryDto dto)
    {
        var category = await repository.GetByIdAsync(dto.CategoryID);

        if (category == null) return;

        category.CategoryName = dto.CategoryName;
        category.Slug = dto.Slug;
        category.Description = dto.Description;
        category.IsActive = dto.IsActive;

        repository.Update(category);

        await repository.SaveAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var category = await repository.GetByIdAsync(id);

        if (category == null) return;

        repository.Delete(category);

        await repository.SaveAsync();
    }
}