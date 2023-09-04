using Domain.Repositories;

namespace Services.Services;

public class ProductDeleteServices : IProductDeleteServices
{
    private readonly IProductRepository _repository;


    public ProductDeleteServices(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _repository.DeleteAsync(id);
    }
}