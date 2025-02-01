using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Order.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Orders;
using LojaOnline.Domain.Products;
using MediatR;

namespace LojaOnline.Application.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<Result<OrderDto>> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = await _orderRepository.GetOrderFullDetailsAsync(request.OrderId);
                if (order == null)
                    return Result<OrderDto>.Failure("Order not found");

                order.UpdateStatus(request.NewStatus);
                await _orderRepository.UpdateAsync(order);
                await _orderRepository.SaveChangesAsync();

                var orderDto = _mapper.Map<OrderDto>(order);
                return Result<OrderDto>.Success(orderDto);
            }
            catch (Exception ex)
            {
                return Result<OrderDto>.Failure($"Error updating order: {ex.Message}");
            }
        }
    }
}
