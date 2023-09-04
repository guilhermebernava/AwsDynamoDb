using Domain.Entities;

namespace Domain.Repositories;

public interface IProductRepository
{
    Task<bool> CreateAsync(Product product);
    Task<bool> UpdateAsync(Product product);
    Task<bool> DeleteAsync(string id);
    Task<Product> GetByIdAsync(string id);
    Task<List<Product>> GetAllAsync();
}
