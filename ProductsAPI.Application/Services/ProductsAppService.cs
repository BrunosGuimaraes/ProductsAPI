using MediatR;
using ProductsAPI.Application.Interfaces.Services;
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

        public ProductsAppService(IMediator? mediator)
        {
            _mediator = mediator;
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
    }
}
