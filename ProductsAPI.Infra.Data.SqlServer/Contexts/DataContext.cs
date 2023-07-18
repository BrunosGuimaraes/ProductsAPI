using Microsoft.EntityFrameworkCore;
using ProductsAPI.Domain.Models;
using ProductsAPI.Infra.Data.SqlServer.Configurations;

namespace ProductsAPI.Infra.Data.SqlServer.Contexts
{
    public class DataContext : DbContext
    {
        //construtor para injeção de dependência
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }

        public DbSet<Product> Products { get; set; }
    }
}
