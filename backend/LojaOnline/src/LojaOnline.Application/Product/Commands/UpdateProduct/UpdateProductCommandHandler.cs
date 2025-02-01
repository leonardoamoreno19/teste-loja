using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Product.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Products;
using MediatR;

namespace LojaOnline.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Result<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<ProductDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await _productRepository.GetByIdAsync(request.Id);
                if (product == null)
                    return Result<ProductDto>.Failure("Product not found");

                if (!string.Equals(product.Name, request.Name) && !await _productRepository.IsNameUniqueAsync(request.Name))
                    return Result<ProductDto>.Failure("Product name must be unique");

                product.Update(request.Name, request.Price);
                await _productRepository.UpdateAsync(product);
                await _productRepository.SaveChangesAsync();

                var productDto = _mapper.Map<ProductDto>(product);
                return Result<ProductDto>.Success(productDto);
            }
            catch (Exception ex)
            {
                return Result<ProductDto>.Failure($"Error updating product: {ex.Message}");
            }
        }
    }
}
