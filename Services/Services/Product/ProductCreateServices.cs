using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using Services.Dtos;

namespace Services.Services;

public class ProductCreateServices : IProductCreateServices
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;


    public ProductCreateServices(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> ExecuteAsync(ProductDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _mapper.Map<Product>(dto);
        return await _repository.CreateAsync(entity);
    }
}
