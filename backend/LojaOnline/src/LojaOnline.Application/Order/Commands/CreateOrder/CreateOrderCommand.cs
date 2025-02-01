using System.Collections.Generic;
using LojaOnline.Application.Order.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommand : ICommand<Result<OrderDto>>
    {
        public int CustomerId { get; set; }
        public List<CreateOrderItemCommand> Items { get; set; }
    }

    public class CreateOrderItemCommand
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
