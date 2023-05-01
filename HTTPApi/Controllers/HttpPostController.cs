using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HTTPLessonApi.Domain.Entity;
using HTTPLessonApi.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HTTPLessonApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HttpPostController : Controller
    {
        private readonly IProductRepository _productRepository;
        
        public HttpPostController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {
                await _productRepository.Insert(product);
                return Ok($"Объект - {product.Name} добавился в БД");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("create-products")]
        public async Task<IActionResult> CreateProducts([FromBody] IEnumerable<Product> product)
        {
            try
            {
                await _productRepository.InsertSomeValues(product);
                return Ok($"Objects added to DB");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost("create-product-only-name/{name}/{description}/{price}")]
        public async Task<IActionResult> CreateProductOnlyName(string name, string description, decimal price)
        {
            try
            {
                var product = new Product()
                {
                    Name = name,
                    Description = description,
                    Price = price
                };
                await _productRepository.Insert(product);
                return Ok($"Object - {product.Name} added to DB");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}