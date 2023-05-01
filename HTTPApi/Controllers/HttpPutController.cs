using System;
using System.Threading.Tasks;
using HTTPLessonApi.Domain.Entity;
using HTTPLessonApi.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HTTPLessonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpPutController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        
        public HttpPutController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpPut("edit-product")]
        public async Task<IActionResult> Edit([FromBody] Product product)
        {
            try
            {
                await _productRepository.Update(product);
                return Ok("Object update");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}