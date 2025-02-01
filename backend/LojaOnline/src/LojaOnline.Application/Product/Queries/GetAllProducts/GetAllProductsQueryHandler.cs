using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Product.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Products;
using MediatR;

namespace LojaOnline.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, Result<List<ProductDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<ProductDto>>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products);
            return Result<List<ProductDto>>.Success(productDtos);
        }
    }
}
