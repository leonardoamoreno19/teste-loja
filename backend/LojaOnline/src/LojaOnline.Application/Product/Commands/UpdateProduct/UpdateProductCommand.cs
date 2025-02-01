using LojaOnline.Application.Product.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Product.Commands.UpdateProduct
{
    public class UpdateProductCommand : ICommand<Result<ProductDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
