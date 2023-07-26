using Bogus;
using FluentAssertions;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;
using ProductsAPI.Tests.Helpers;
using System.Net;
using Xunit;

namespace ProductsAPI.Tests
{
    public class ProductsTest
    {
        private readonly string? _endpoint;
        private readonly Faker? _faker;
        public ProductsTest()
        {
            _endpoint = "/api/products";
            _faker = new Faker("pt_BR");
        }

        [Fact]
        public async Task<ProductsDTO> Test_Products_Post_Returns_Created()
        {
            //definindo os dados da requisição
            var command = new ProductsCreateCommand
            {
                Name = _faker?.Commerce.ProductName(),
                Price = decimal.Parse(_faker?.Commerce.Price(2)),
                Quantity = _faker.Random.Number(1, 100)
            };

            //Criando um objeto HTTP CLIENT para executar chamadas API
            var client = TestHelper.CreateClient;

            var result = await client.PostAsync(_endpoint, TestHelper.CreateContent(command));

            //Verifica se o retorno é CREATED (201)
            result.StatusCode.Should().Be(HttpStatusCode.Created);

            return TestHelper.ReadResponse<ProductsDTO>(result);
        }

        [Fact]
        public async Task Test_Products_Put_Returns_Ok()
        {
            var dto = await Test_Products_Post_Returns_Created();

            var command = new ProductsUpdateCommand
            {
                Id = dto.Id.Value,
                Name = _faker?.Commerce.ProductName(),
                Price = decimal.Parse(_faker?.Commerce.Price(2)),
                Quantity = _faker.Random.Number(1, 100)
            };

            var client = TestHelper.CreateClient;

            var result = await client.PutAsync(_endpoint, TestHelper.CreateContent(command));

            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Test_Products_Delete_Returns_Ok()
        {
            var dto = await Test_Products_Post_Returns_Created();

            var command = new ProductsUpdateCommand
            {
                Id = dto.Id.Value,
                Name = _faker?.Commerce.ProductName(),
                Price = decimal.Parse(_faker?.Commerce.Price(2)),
                Quantity = _faker.Random.Number(1, 100)
            };

            var client = TestHelper.CreateClient;

            var result = await client.DeleteAsync($"{_endpoint}/{dto.Id.Value}");

            result.StatusCode.Should().Be(HttpStatusCode.OK);

        }

        [Fact]
        public async Task Test_Products_GetAll_Returns_Ok()
        {
            var dto = await Test_Products_Post_Returns_Created();

            var command = new ProductsUpdateCommand
            {
                Id = dto.Id.Value,
                Name = _faker?.Commerce.ProductName(),
                Price = decimal.Parse(_faker?.Commerce.Price(2)),
                Quantity = _faker.Random.Number(1, 100)
            };

            var client = TestHelper.CreateClient;

            var result = await client.GetAsync(_endpoint);

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var list = TestHelper.ReadResponse<List<ProductsDTO>>(result);

            //Verifica se o produto cadastrado está na lista
            list.FirstOrDefault(p => p.Id.Value.Equals(dto.Id.Value)).Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Products_GetById_Returns_Ok()
        {
            var dto = await Test_Products_Post_Returns_Created();

            var command = new ProductsUpdateCommand
            {
                Id = dto.Id.Value,
                Name = _faker?.Commerce.ProductName(),
                Price = decimal.Parse(_faker?.Commerce.Price(2)),
                Quantity = _faker.Random.Number(1, 100)
            };

            var client = TestHelper.CreateClient;

            var result = await client.GetAsync($"{_endpoint}/{dto.Id.Value}");

            result.StatusCode.Should().Be(HttpStatusCode.OK);

            var item = TestHelper.ReadResponse<ProductsDTO>(result);

            item.Id.Should().Be(dto.Id);
            item.Name.Should().Be(dto.Name);
            item.Price.Should().Be(dto.Price);
            item.Quantity.Should().Be(dto.Quantity);
        }
    }
}