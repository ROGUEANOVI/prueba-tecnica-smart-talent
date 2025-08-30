using AutoMapper;
using Backend.Application.DTOs;
using Backend.Application.Exceptions;
using Backend.Application.Interfaces;

namespace Backend.Application.Features.Products.Commands.Update
{
    public class UpdateProductCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommand(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task ExecuteAsync(int id, CreateUpdateProductDto productDto)
        {
            var productToUpdate = await _productRepository.GetByIdAsync(id);
            if (productToUpdate == null)
            {
                throw new NotFoundException($"No se encontró el producto con el ID {id}.");
            }

            var existingProduct = await _productRepository.GetByNameAsync(productDto.Name);
            if (existingProduct != null && existingProduct.Id != id)
            {
                throw new BadRequestException($"Ya existe otro producto con el nombre '{productDto.Name}'.");
            }

            if (productDto.Price <= 0)
            {
                throw new BadRequestException("El precio del producto debe ser mayor a cero.");
            }

            _mapper.Map(productDto, productToUpdate);

            await _productRepository.UpdateAsync(productToUpdate);
        }
    }
}
