using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Interfaces.Stores
{
    public interface IProductStore
    {
        void Add(ProductsDTO item);
        void Update(ProductsDTO item);
        void Delete(Guid Id);
        List<ProductsDTO> GetAll();
        ProductsDTO GetById(Guid Id);
    }
}
