using Backend.Application.DTOs;
using Backend.Application.Features.Products.Commands.Create;
using Backend.Application.Features.Products.Commands.Delete;
using Backend.Application.Features.Products.Commands.Update;
using Backend.Application.Features.Products.Queries.GetAll;
using Backend.Application.Features.Products.Queries.GetById;
using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Controllers
{
    /// <summary>
    /// Controlador para la gestión de Productos.
    /// </summary>
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


        /// <summary>
        /// Obtiene una lista paginada de productos.
        /// </summary>
        /// <param name="pageNumber">El número de página a solicitar (por defecto: 1).</param>
        /// <param name="pageSize">El tamaño de la página (por defecto: 10).</param>
        /// <returns>Un objeto con la lista de productos y la información de paginación.</returns>
        /// <response code="200">Retorna la lista paginada de productos.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponseDto<ProductDto>))]
        public async Task<IActionResult> GetAllProducts([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var pagedResponse = await _getAllProductsQuery.ExecuteAsync(pageNumber, pageSize);
            return Ok(pagedResponse);
        }

        /// <summary>
        /// Obtiene un producto específico por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a buscar.</param>
        /// <returns>El producto encontrado.</returns>
        /// <response code="200">Retorna el producto solicitado.</response>
        /// <response code="404">Si no se encuentra ningún producto con ese ID.</response>
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

        /// <summary>
        /// Crea un nuevo producto.
        /// </summary>
        /// <param name="productDto">Los datos para crear el nuevo producto.</param>
        /// <returns>La URL del nuevo producto creado.</returns>
        /// <response code="201">Producto creado exitosamente.</response>
        /// <response code="400">Si los datos del producto no son válidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProductDto productDto)
        {
            var productId = await _createProductCommand.ExecuteAsync(productDto);

            return CreatedAtAction(nameof(GetProductById), new { id = productId }, new { id = productId });
        }

        /// <summary>
        /// Actualiza un producto existente.
        /// </summary>
        /// <param name="id">El ID del producto a actualizar.</param>
        /// <param name="productDto">Los nuevos datos del producto.</param>
        /// <response code="204">Producto actualizado exitosamente.</response>
        /// <response code="400">Si los datos del producto no son válidos.</response>
        /// <response code="404">Si no se encuentra el producto.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] CreateUpdateProductDto productDto)
        {
            await _updateProductCommand.ExecuteAsync(id, productDto);

            return NoContent();
        }

        /// <summary>
        /// Elimina un producto por su ID.
        /// </summary>
        /// <param name="id">El ID del producto a eliminar.</param>
        /// <response code="204">Producto eliminado exitosamente.</response>
        /// <response code="404">Si no se encuentra el producto.</response>
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
