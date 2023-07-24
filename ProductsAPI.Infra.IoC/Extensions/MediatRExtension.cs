using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProductsAPI.Infra.IoC.Extensions
{
    public static class MediatRExtension
    {
        public static IServiceCollection AddMediatRConfig(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}
