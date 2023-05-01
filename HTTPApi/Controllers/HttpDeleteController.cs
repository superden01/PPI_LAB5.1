using System;
using System.Threading.Tasks;
using HTTPLessonApi.Domain.Entity;
using HTTPLessonApi.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HTTPLessonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpDeleteController : Controller
    {
        private readonly IProductRepository _productRepository;
        
        public HttpDeleteController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpDelete("delete-product/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productRepository.Get(id);
                if (product != null)
                {
                    await _productRepository.Delete(product);
                    return Ok($"Object - {product.Name} Deleted");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("delete-product-by-name/{name}")]
        public async Task<IActionResult> DeleteByName(string name)
        {
            try
            {
                var product = await _productRepository.GetByParameter(name);
                if (product != null)
                {
                    await _productRepository.Delete(product);
                    return Ok($"Object - {product.Name} Deleted");
                }   
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}