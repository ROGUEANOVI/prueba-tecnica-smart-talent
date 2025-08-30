using Backend.Application.DTOs;
using Backend.Application.Features.Products.Commands.Create;
using Backend.Application.Features.Products.Commands.Delete;
using Backend.Application.Features.Products.Commands.Update;
using Backend.Application.Features.Products.Queries.GetAll;
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
        private readonly UpdateProductCommand _updateProductCommand;
        private readonly DeleteProductCommand _deleteProductCommand;
        private readonly GetAllProductsQuery _getAllProductsQuery;

        public ProductsController(
            CreateProductCommand createProductUseCase, 
            GetProductByIdQuery getProductByIdQuery, 
            UpdateProductCommand updateProductCommand,
            DeleteProductCommand deleteProductCommand,
            GetAllProductsQuery getAllProductsQuery)
        {
            _createProductCommand = createProductUseCase;
            _getProductByIdQuery = getProductByIdQuery;
            _updateProductCommand = updateProductCommand;
            _deleteProductCommand = deleteProductCommand;
            _getAllProductsQuery = getAllProductsQuery;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponseDto<ProductDto>))]
        public async Task<IActionResult> GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var pagedResponse = await _getAllProductsQuery.ExecuteAsync(pageNumber, pageSize);
            return Ok(pagedResponse);
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

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CreateUpdateProductDto productDto)
        {
            await _updateProductCommand.ExecuteAsync(id, productDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _deleteProductCommand.ExecuteAsync(id);

            return NoContent();
        }
    }
}
