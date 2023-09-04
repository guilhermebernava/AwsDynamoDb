using Domain.Entities;

namespace Services.Services;

public interface IProductGetByIdServices
{
    Task<Product> ExecuteAsync(string id, CancellationToken cancellationToken = default);
}
