using Backend.Application.DTOs;
using Backend.Application.Features.Products.Commands.Create;
using Backend.Application.Features.Products.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CreateProductCommand _createProductCommand;
        private readonly GetProductByIdQuery _getProductByIdQuery;

        public ProductsController(CreateProductCommand createProductUseCase, GetProductByIdQuery getProductByIdQuery)
        {
            _createProductCommand = createProductUseCase;
            _getProductByIdQuery = getProductByIdQuery;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _getProductByIdQuery.ExecuteAsync(id);
            
            if (product == null)
            {
                return NotFound();
            }
            
            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProductDto productDto)
        {
            var productId = await _createProductCommand.ExecuteAsync(productDto);

            return CreatedAtAction(nameof(GetProductById), new { id = productId }, new { id = productId });
        }
    }
}
