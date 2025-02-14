using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Dtos.RequestDtos;
using Product.IService;

namespace Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("Add-Product")]

        public async Task<IActionResult> AddProduct(ProductRequestDtos productRequestDtos)
        {
            try
            {
                var data = await _productService.AddProducts(productRequestDtos).ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Get-Product-By-Id/{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            try
            {
                var data = await _productService.GetProductById(id).ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Get-All-Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var data = await _productService.GetAllProducts().ConfigureAwait(false);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
