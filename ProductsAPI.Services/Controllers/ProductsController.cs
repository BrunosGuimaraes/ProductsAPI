using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Application.Interfaces.Services;
using ProductsAPI.Application.Models.Commands;
using ProductsAPI.Application.Models.Queries;

namespace ProductsAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsAppService? _productsAppService;

        public ProductsController(IProductsAppService? productsAppService)
        {
            _productsAppService = productsAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProductsDTO), 201)]
        public async Task<IActionResult> Post([FromBody] ProductsCreateCommand command)
        {
            var response = await _productsAppService.Create(command);
            return StatusCode(201, response);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductsDTO), 200)]
        public async Task<IActionResult> Put([FromBody] ProductsUpdateCommand command)
        {
            var response = await _productsAppService.Update(command);
            return StatusCode(200, response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProductsDTO), 200)]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var command = new ProductsDeleteCommand { Id = id };
            var response = await _productsAppService.Delete(command);
            return StatusCode(200, response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProductsDTO>), 200)]
        public IActionResult Get() 
        {
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductsDTO), 200)]
        public IActionResult Get(Guid? id)
        {
            return Ok();
        }
    }
}
