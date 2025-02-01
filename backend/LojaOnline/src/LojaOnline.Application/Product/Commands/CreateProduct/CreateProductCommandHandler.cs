using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Product.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Products;
using MediatR;

namespace LojaOnline.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (!await _productRepository.IsNameUniqueAsync(request.Name))
                    return Result<ProductDto>.Failure("Product name must be unique");

                var product = new Domain.Entities.Product(request.Name, request.Price);
                await _productRepository.AddAsync(product);
                
                await _productRepository.SaveChangesAsync();

                var productDto = _mapper.Map<ProductDto>(product);
                return Result<ProductDto>.Success(productDto);
            }
            catch (Exception ex)
            {
                return Result<ProductDto>.Failure($"Error creating product: {ex.Message}");
            }
        }
    }
}
