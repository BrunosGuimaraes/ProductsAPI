namespace ProductsAPI.Application.Models.Queries
{
    /// <summary>
    /// Modelo de dados para o serviço de consulta de produtos
    /// </summary>
    public class ProductsDTO
    {
        public Guid? Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public decimal? Total { get => Price * Quantity; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
