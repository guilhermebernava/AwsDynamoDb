using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Services.Dtos;

namespace Services.Services;
public class ProductUpdateServices : IProductUpdateServices
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;


    public ProductUpdateServices(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> ExecuteAsync(ProductUpdateDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Product>(dto);
        return await _repository.UpdateAsync(entity);
    }
}