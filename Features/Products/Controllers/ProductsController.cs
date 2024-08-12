using BuriPosApi.Models;
using Microsoft.AspNetCore.Mvc;

using BuriPosApi.Interfaces;

namespace BuriPosApi.Features.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _unitOfWork.ProductRepository.GetProductsAsync();
            return Ok(products);
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _unitOfWork.ProductRepository.FindProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }
            return Ok(product);
        }

        // POST: api/product
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest("Product cannot be null.");
            }

            await _unitOfWork.ProductRepository.AddProductAsync(product);
            await _unitOfWork.CompleteAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.ProductRepository.FindProductByIdAsync(id);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            await _unitOfWork.ProductRepository.DeleteProductAsync(id);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
