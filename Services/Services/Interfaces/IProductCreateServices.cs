using Services.Dtos;

namespace Services.Services;

public interface IProductCreateServices
{
    Task<bool> ExecuteAsync(ProductDto dto, CancellationToken cancellationToken = default);
}
