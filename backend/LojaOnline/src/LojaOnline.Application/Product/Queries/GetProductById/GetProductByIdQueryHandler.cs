using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Product.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Products;
using MediatR;

namespace LojaOnline.Application.Product.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Result<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                return Result<ProductDto>.Failure("Product not found");

            var productDto = _mapper.Map<ProductDto>(product);
            return Result<ProductDto>.Success(productDto);
        }
    }
}
