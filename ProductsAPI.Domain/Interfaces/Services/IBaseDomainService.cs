namespace ProductsAPI.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity, TKey> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(TKey id);
        List<TEntity> GetAll();
    }
}
