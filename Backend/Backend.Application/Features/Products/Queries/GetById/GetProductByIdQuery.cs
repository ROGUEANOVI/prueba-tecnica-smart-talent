using AutoMapper;
using Backend.Application.DTOs;
using Backend.Application.Interfaces;

namespace Backend.Application.Features.Products.Queries.GetById
{
    public class GetProductByIdQuery
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQuery(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto?> ExecuteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
            {
                return null;
            }
            return _mapper.Map<ProductDto>(product);
        }
    }
}
