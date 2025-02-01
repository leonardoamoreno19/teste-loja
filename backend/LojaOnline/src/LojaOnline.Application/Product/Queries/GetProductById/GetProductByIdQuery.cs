using LojaOnline.Application.Product.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IQuery<Result<ProductDto>>
    {
        public int Id { get; set; }
    }
}
