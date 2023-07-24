using ProductsAPI.Domain.Interfaces.Repositories;
using ProductsAPI.Domain.Interfaces.Services;

namespace ProductsAPI.Domain.Services
{
    public abstract class BaseDomainService<TEntity, TKey> : IBaseDomainService<TEntity, TKey>, IDisposable
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity, TKey>? _baseRepository;

        protected BaseDomainService(IBaseRepository<TEntity, TKey>? baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual void Add(TEntity entity)
        {
            _baseRepository?.Add(entity);
            _baseRepository?.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _baseRepository?.Update(entity);
            _baseRepository?.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _baseRepository?.Delete(entity);
            _baseRepository?.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return _baseRepository?.GetAll();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _baseRepository?.GetById(id);
        }

        public virtual void Dispose()
        {
            _baseRepository?.Dispose();
        }
    }
}