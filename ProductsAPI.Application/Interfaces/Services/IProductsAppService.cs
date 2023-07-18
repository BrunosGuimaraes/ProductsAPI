using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Interfaces.Services
{
    /// <summary>
    /// Interface para os serviços da aplicação
    /// </summary>
    public interface IProductsAppService
    {
        Task<ProductsDTO> Create(ProductsCreateCommand command);
        Task<ProductsDTO> Update(ProductsUpdateCommand command);
        Task<ProductsDTO> Delete(ProductsDeleteCommand command);
    }
}
