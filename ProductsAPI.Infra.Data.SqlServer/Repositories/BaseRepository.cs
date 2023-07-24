using ProductsAPI.Domain.Interfaces.Repositories;
using ProductsAPI.Infra.Data.SqlServer.Contexts;

namespace ProductsAPI.Infra.Data.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        private readonly DataContext? _dataContext;

        protected BaseRepository(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual void Add(TEntity entity)
        {
            _dataContext?.Set<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _dataContext?.Set<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dataContext?.Set<TEntity>().Remove(entity);
        }

        public virtual List<TEntity> GetAll()
        {
            return _dataContext?.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _dataContext?.Set<TEntity>().Find(id);
        }

        public virtual void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public virtual void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
