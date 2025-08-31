using Backend.Application.Exceptions;
using Backend.Application.Interfaces;

namespace Backend.Application.Features.Products.Commands.Delete
{
    public class DeleteProductCommand
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommand(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task ExecuteAsync(int id)
        {
            var productToDelete = await _productRepository.GetByIdAsync(id);
            if (productToDelete == null)
            {
                throw new NotFoundException($"No se encontró el producto con el ID {id}.");
            }

            await _productRepository.DeleteAsync(id);
        }
    }
}
