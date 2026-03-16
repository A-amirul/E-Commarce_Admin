using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Application.Services;

public class ProductService
{
    private readonly IRepository<Product> _repository;

    public ProductService(IRepository<Product> repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Product?> Get(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task Create(Product product)
    {
        await _repository.AddAsync(product);
        await _repository.SaveAsync();
    }

    public async Task Update(Product product)
    {
        _repository.Update(product);
        await _repository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product != null)
        {
            _repository.Delete(product);
            await _repository.SaveAsync();
        }
    }
}