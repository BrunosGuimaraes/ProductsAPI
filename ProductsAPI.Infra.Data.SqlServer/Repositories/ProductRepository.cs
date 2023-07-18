using ProductsAPI.Domain.Interfaces.Repositories;
using ProductsAPI.Domain.Models;
using ProductsAPI.Infra.Data.SqlServer.Contexts;

namespace ProductsAPI.Infra.Data.SqlServer.Repositories
{
    public class ProductRepository : BaseRepository<Product, Guid>, IProductRepository
    {
        private readonly DataContext? _dataContext;
        public ProductRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
