using ProductsAPI.Domain.Entities;

namespace ProductsAPI.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IBaseRepository<Product, Guid>
    {

    }
}
