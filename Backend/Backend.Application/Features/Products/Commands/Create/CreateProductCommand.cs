using AutoMapper;
using Backend.Application.DTOs;
using Backend.Application.Exceptions;
using Backend.Application.Interfaces;
using Backend.Domain.Entities;

namespace Backend.Application.Features.Products.Commands.Create
{
    public class CreateProductCommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommand(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<int> ExecuteAsync(CreateUpdateProductDto productDto)
        {
            var existingProduct = await _productRepository.GetByNameAsync(productDto.Name);
            
            if (existingProduct != null)
            {
                throw new BadRequestException($"Ya existe un producto con el nombre '{productDto.Name}'.");
            }

            if (productDto.Price <= 0)
            {
                throw new BadRequestException("El precio del producto debe ser mayor a cero.");
            }
            
            var product = _mapper.Map<Product>(productDto);

            var newProduct = await _productRepository.AddAsync(product);

            return newProduct.Id;
        }
    }
}
