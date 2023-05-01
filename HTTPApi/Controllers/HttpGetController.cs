using System.Linq;
using System.Threading.Tasks;
using HTTPLessonApi.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HTTPLessonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpGetController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        
        public HttpGetController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpGet("get-all-products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepository.Select();
            if (products.Count() != 0)
            {
                return Ok(products);
            }
            return NoContent();
        }
        
        [HttpGet("get-product/{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productRepository.Get(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NoContent();
        }
        
        [HttpGet("get-product-by-name/{name}")]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _productRepository.GetByParameter(name);
            if (product != null)
            {
                return Ok(product);
            }
            return NoContent();
        }
    }
}