using Domain.Entities;
using Domain.Repositories;

namespace Services.Services;
public class ProductGetAllServices : IProductGetAllServices
{
    private readonly IProductRepository _repository;


    public ProductGetAllServices(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<Product>> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.GetAllAsync();
    }
}