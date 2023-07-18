using ProductsAPI.Domain.Interfaces.Repositories;
using ProductsAPI.Infra.Data.SqlServer.Contexts;

namespace ProductsAPI.Infra.Data.SqlServer.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DataContext? _dataContext;

        public UnitOfWork(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public IProductRepository ProductRepository => new ProductRepository(_dataContext);

        public void Dispose()
        {
            _dataContext?.Dispose();
        }

        public void SaveChanges()
        {
            _dataContext?.SaveChanges();
        }
    }
}
