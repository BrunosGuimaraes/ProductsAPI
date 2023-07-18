using MongoDB.Driver;
using ProductsAPI.Application.Interfaces.Stores;
using ProductsAPI.Application.Models.Queries;
using ProductsAPI.Infra.Data.MongoDB.Contexts;

namespace ProductsAPI.Infra.Data.MongoDB.Stores
{
    public class ProductStore : IProductStore
    {
        private readonly MongoDBContext? _mongoDBContext;
        public ProductStore(MongoDBContext? mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public void Add(ProductsDTO item)
        {
            _mongoDBContext?.Products.InsertOne(item);
        }

        public void Delete(Guid Id)
        {
            var filter = Builders<ProductsDTO>.Filter.Eq(p => p.Id, Id);
            _mongoDBContext?.Products.DeleteOne(filter);
        }

        public List<ProductsDTO> GetAll()
        {
            var filter = Builders<ProductsDTO>.Filter.Where(p => true);
            return _mongoDBContext?.Products.Find(filter).ToList();
        }

        public ProductsDTO GetById(Guid Id)
        {
            var filter = Builders<ProductsDTO>.Filter.Eq(p=>p.Id, Id);
            return _mongoDBContext?.Products.Find(filter).FirstOrDefault();
        }

        public void Update(ProductsDTO item)
        {
            var filter = Builders<ProductsDTO>.Filter.Eq(p => p.Id, item.Id);
            _mongoDBContext?.Products.ReplaceOne(filter, item);
        }
    }
}
