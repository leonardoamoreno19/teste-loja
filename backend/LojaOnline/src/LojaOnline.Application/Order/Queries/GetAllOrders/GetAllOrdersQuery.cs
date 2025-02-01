using System.Collections.Generic;
using LojaOnline.Application.Order.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Order.Queries.GetAllOrders
{
    public class GetAllOrdersQuery : IQuery<Result<List<OrderDto>>>
    {
    }
}
