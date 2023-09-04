using Domain.Entities;
using Domain.Repositories;

namespace Services.Services;
public class ProductGetByIdServices : IProductGetByIdServices
{
    private readonly IProductRepository _repository;


    public ProductGetByIdServices(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<Product> ExecuteAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(id);
    }
}