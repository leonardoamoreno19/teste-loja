using LojaOnline.Application.Order.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Enums;

namespace LojaOnline.Application.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommand : ICommand<Result<OrderDto>>
    {
        public int OrderId { get; set; }
        public OrderStatus NewStatus { get; set; }
    }
}
