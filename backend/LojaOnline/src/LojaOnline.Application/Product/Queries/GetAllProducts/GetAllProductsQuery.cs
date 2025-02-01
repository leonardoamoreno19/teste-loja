using System.Collections.Generic;
using LojaOnline.Application.Product.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Product.Queries.GetAllProducts
{
    public class GetAllProductsQuery : IQuery<Result<List<ProductDto>>>
    {
    }
}
