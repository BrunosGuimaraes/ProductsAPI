using MediatR;
using ProductsAPI.Application.Models.Queries;
using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.Application.Models.Commands
{
    /// <summary>
    /// Modelo de dados para o serviço de criação de produto
    /// </summary>
    public class ProductsCreateCommand : IRequest<ProductsDTO>
    {
        [Required(ErrorMessage = "Informe o nome do produto.")]
        [MinLength(8, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(150, ErrorMessage = "Informe no máximo {1} caracteres.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Informe o preço do produto.")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Informe a quantidade do produto.")]
        public int? Quantity { get; set; }
    }
}
