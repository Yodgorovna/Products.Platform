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

        [HttpGet("{getbyid}")]
        public async Task<IActionResult> GetByIdAsync(Guid getbyid)
            => Ok(await _service.GetByIdAsync(getbyid));

        [HttpGet("searchTerm")]
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

        [HttpGet("orderbydesending-brand")]
        public async Task<IActionResult> OrderByDesendingBrand()
            => Ok(await _service.OrderByDesendingBrand());

        [HttpGet("orderby-brand")]
        public async Task<IActionResult> OrderByBrand()
            => Ok(await _service.OrderByBrand());

        [HttpGet("orderbydesending-id")]
        public async Task<IActionResult> OrderByDesendingId()
            => Ok(await _service.OrderByDesendingId());

        [HttpGet("orderby-id")]
        public async Task<IActionResult> OrderById()
            => Ok(await _service.OrderById());

        [HttpGet("orderbydesending-price")]
        public async Task<IActionResult> OrderByDesendingPrice()
            => Ok(await _service.OrderByDesendingPrice());

        [HttpGet("orderby-price")]
        public async Task<IActionResult> OrderByPrice()
            => Ok(await _service.OrderByPrice());


        [HttpGet("orderby-createdat")]
        public async Task<IActionResult> OrderByCreatedAt()
           => Ok(await _service.OrderByCreatedAt());

        [HttpGet("orderbydesending-createdat")]
        public async Task<IActionResult> OrderByDesendingCreatedAt()
            => Ok(await _service.OrderByDesendingCreatedAt());

        [HttpGet("orderbydesending-updatedat")]
        public async Task<IActionResult> OrderByDesendingUpdatedAt()
          => Ok(await _service.OrderByDesendingUpdatedAt());

        [HttpGet("orderby-updatedat")]
        public async Task<IActionResult> OrderByUpdatedAt()
            => Ok(await _service.OrderByUpdatedAt());
    }
}
