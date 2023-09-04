using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Services;

public static class ServicesInjections
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IProductCreateServices, ProductCreateServices>();
        services.AddScoped<IProductUpdateServices, ProductUpdateServices>();
        services.AddScoped<IProductDeleteServices, ProductDeleteServices>();
        services.AddScoped<IProductGetAllServices, ProductGetAllServices>();
        services.AddScoped<IProductGetByIdServices, ProductGetByIdServices>();
    }
}
