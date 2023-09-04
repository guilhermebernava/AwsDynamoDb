using Services.Dtos;

namespace Services.Services;

public interface IProductUpdateServices
{
    Task<bool> ExecuteAsync(ProductUpdateDto dto, CancellationToken cancellationToken = default);
}
