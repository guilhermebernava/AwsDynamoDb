using Domain.Entities;

namespace Services.Services;

public interface IProductGetAllServices
{
    Task<List<Product>> ExecuteAsync(CancellationToken cancellationToken = default);
}
