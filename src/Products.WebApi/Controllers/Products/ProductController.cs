using Microsoft.AspNetCore.Mvc;
using Products.Service.Dtos.Products;
using Products.Service.Interfaces.Products;

namespace Products.WebApi.Controllers.Products
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _service;

        public ProductController(IProductService service)
        {
            this._service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductDto dto)
        {
            return Ok(await _service.CreateAsync(dto));
        }
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteAsync(Guid productId)
            => Ok(await _service.DeleteAsync(productId));

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateAsync(ProductDto dto, Guid productId)
            => Ok(await _service.Update(productId, dto));

        [HttpGet("{searchTerm}")]
        public async Task<IActionResult> SearchAsync(string searchTerm)
            => Ok(await _service.SearchAsync(searchTerm));

        [HttpGet("orderbydesending-name")]
        public async Task<IActionResult> OrderByDesendingName()
            => Ok(await _service.OrderByDesendingName());

        [HttpGet("orderby-name")]
        public async Task<IActionResult> OrderByName()
         => Ok(await _service.OrderByName());

        [HttpGet("orderbydesending-type")]
        public async Task<IActionResult> OrderByDesendingType()
     => Ok(await _service.OrderByDesendingType());

        [HttpGet("orderby-type")]
        public async Task<IActionResult> OrderByType()
         => Ok(await _service.OrderByType());

    }
}
