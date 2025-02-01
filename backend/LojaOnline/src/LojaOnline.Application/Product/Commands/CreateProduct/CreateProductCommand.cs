using LojaOnline.Application.Product.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : ICommand<Result<ProductDto>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
