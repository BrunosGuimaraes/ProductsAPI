using MediatR;
using ProductsAPI.Application.Handlers.Notifications;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;
using ProductsAPI.Domain.Entities;
using ProductsAPI.Domain.Interfaces.Services;
using System.Diagnostics;

namespace ProductsAPI.Application.Handlers.Requests
{
    /// <summary>
    /// Componente para 'escutar' as requisições do tipo COMMAND de produtos 
    /// </summary>
    public class ProductsRequestHandler :
        IRequestHandler<ProductsCreateCommand, ProductsDTO>,
        IRequestHandler<ProductsUpdateCommand, ProductsDTO>,
        IRequestHandler<ProductsDeleteCommand, ProductsDTO>
    {
        private readonly IMediator? _mediator;
        private readonly IProductDomainService? _productDomainService;

        public ProductsRequestHandler(IMediator? mediator, IProductDomainService? productDomainService)
        {
            _mediator = mediator;
            _productDomainService = productDomainService;
        }
        /// <summary>
        /// Métodos para processar o COMMAND CREATE do produto 
        /// </summary>
        public async Task<ProductsDTO> Handle(ProductsCreateCommand request, CancellationToken cancellationToken)
        {
            //captura os dados do request para criar um novo produto
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Price = request.Price,
                Quantity = request.Quantity,
                CreationDate = DateTime.Now
            };

            //envia o produto para ser cadastrado no domínio
            _productDomainService?.Add(product);

            //copia os dados do produto para um DTO
            var productDto = new ProductsDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreationDate = product.CreationDate,
                LastModifiedDate = product.LastModifiedDate
            };

            //envia uma notificação para que o DTO seja gravado em um banco de dados para leitura (MongoDB)
            await _mediator.Publish(new ProductsNotification
            {
                Action = ActionNotification.Created,
                ProductsDto = productDto
            });

            return productDto;
        }

        public async Task<ProductsDTO> Handle(ProductsUpdateCommand request, CancellationToken cancellationToken)
        {
            //captura os dados do request para um novo produto
            var product = _productDomainService.GetById(request.Id);
            
            product.Name = request.Name;
            product.Price = request.Price;
            product.Quantity = request.Quantity;
            product.LastModifiedDate = DateTime.Now;

            //envia o produto para ser atualizado no domínio
            _productDomainService?.Update(product);

            //copia os dados do produto para um DTO
            var produtctDto = new ProductsDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreationDate = product.CreationDate,
                LastModifiedDate = product.LastModifiedDate
            };

            //envia uma notificação para que o DTO seja atualizado em um banco de dados para leitura (MongoDB)
            await _mediator.Publish(new ProductsNotification
            {
                Action = ActionNotification.Updated,
                ProductsDto = produtctDto
            });

            return produtctDto;
        }

        public async Task<ProductsDTO> Handle(ProductsDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = _productDomainService.GetById(request.Id);

            //envia o produto para ser excluído no domínio
            _productDomainService.Delete(product);

            //copia os dados do produto para um DTO
            var produtctDto = new ProductsDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreationDate = product.CreationDate,
                LastModifiedDate = product.LastModifiedDate
            };

            //envia uma notificação para que o DTO seja excluído em um banco de dados para leitura (MongoDB)
            await _mediator.Publish(new ProductsNotification
            {
                Action = ActionNotification.Deleted,
                ProductsDto = produtctDto
            });

            return produtctDto;
        }
    }
}
