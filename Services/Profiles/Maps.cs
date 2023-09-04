using AutoMapper;
using Domain.Entities;
using Services.Dtos;

namespace Services.Profiles;

public class Maps : Profile
{
    public Maps()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<ProductUpdateDto, Product>();
    }
}
