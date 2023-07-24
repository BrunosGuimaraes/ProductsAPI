using MediatR;
using ProductsAPI.Application.Interfaces.Services;
using ProductsAPI.Application.Interfaces.Stores;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Services
{
    /// <summary>
    /// Implementação dos serviços da aplicação
    /// </summary>
    public class ProductsAppService : IProductsAppService
    {
        private readonly IMediator? _mediator;
        private readonly IProductStore _productStore;

        public ProductsAppService(IMediator? mediator, IProductStore productStore)
        {
            _mediator = mediator;
            _productStore = productStore;
        }

        public async Task<ProductsDTO> Create(ProductsCreateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ProductsDTO> Update(ProductsUpdateCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<ProductsDTO> Delete(ProductsDeleteCommand command)
        {
            return await _mediator.Send(command);
        }

        public List<ProductsDTO> GetAll()
        {
           return _productStore?.GetAll();
        }

        public ProductsDTO GetById(Guid id)
        {
            return _productStore?.GetById(id);
        }
    }
}
