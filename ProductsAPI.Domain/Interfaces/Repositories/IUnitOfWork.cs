namespace ProductsAPI.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        void SaveChanges();
    }
}
