using AutoMapper;
using Backend.Application.DTOs;
using Backend.Application.Interfaces;

namespace Backend.Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQuery
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQuery(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponseDto<ProductDto>> ExecuteAsync(int pageNumber, int pageSize)
        {
            pageNumber = pageNumber < 1 ? 1 : pageNumber;
            pageSize = pageSize < 1 ? 10 : pageSize;

            var (products, totalRecords) = await _productRepository.GetPagedAsync(pageNumber, pageSize);

            var productDtos = _mapper.Map<List<ProductDto>>(products);

            return new PagedResponseDto<ProductDto>(productDtos, pageNumber, pageSize, totalRecords);
        }
    }
}
