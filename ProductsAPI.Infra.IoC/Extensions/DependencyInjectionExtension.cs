using Microsoft.Extensions.DependencyInjection;
using ProductsAPI.Application.Interfaces.Services;
using ProductsAPI.Application.Interfaces.Stores;
using ProductsAPI.Application.Services;
using ProductsAPI.Domain.Interfaces.Repositories;
using ProductsAPI.Domain.Interfaces.Services;
using ProductsAPI.Domain.Services;
using ProductsAPI.Infra.Data.MongoDB.Stores;
using ProductsAPI.Infra.Data.SqlServer.Repositories;

namespace ProductsAPI.Infra.IoC.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<IProductDomainService, ProductDomainService>();
            services.AddTransient<IProductsAppService, ProductsAppService>();
            services.AddTransient<IProductStore, ProductStore>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
