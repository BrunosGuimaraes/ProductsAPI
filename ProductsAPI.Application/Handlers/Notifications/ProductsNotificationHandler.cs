using MediatR;
using System.Diagnostics;

namespace ProductsAPI.Application.Handlers.Notifications
{
    /// <summary>
    /// Componente para 'escutar' o resultado do processamento dos RequestHandlers
    /// e executar as operações de CREATE, UPDATE ou DELETE no banco de cache
    /// </summary>
    public class ProductsNotificationHandler : INotificationHandler<ProductsNotification>
    {
        public Task Handle(ProductsNotification notification, CancellationToken cancellationToken)
        {
            Debug.WriteLine($"Recebendo notificação de: {notification.Action}");
            Debug.WriteLine($"Produto gravado, alterado ou excluido no banco de cache!");
            Debug.WriteLine($"{notification.ProductsQuery.Name}");

            return Task.CompletedTask;
        }
    }
}
