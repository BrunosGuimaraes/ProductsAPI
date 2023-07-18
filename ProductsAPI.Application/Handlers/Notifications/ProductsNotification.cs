using MediatR;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Application.Handlers.Notifications
{
    /// <summary>
    /// Modelo de dados da notification de produtos
    /// </summary>
    public class ProductsNotification : INotification
    {
        public ActionNotification? Action { get; set; }
        public ProductsDTO? ProductsQuery { get; set; }
    }

    public enum ActionNotification
    {
        Created,
        Updated,
        Deleted
    }
}
