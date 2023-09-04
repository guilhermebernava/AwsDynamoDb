namespace Services.Services;

public interface IProductDeleteServices
{
    Task<bool> ExecuteAsync(string id, CancellationToken cancellationToken = default);
}
