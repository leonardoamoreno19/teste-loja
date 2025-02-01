using LojaOnline.Application.Order.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IQuery<Result<OrderDto>>
    {
        public int OrderId { get; set; }
    }
}
