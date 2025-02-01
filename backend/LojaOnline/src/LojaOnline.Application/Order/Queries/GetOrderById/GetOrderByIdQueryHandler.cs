using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Order.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Orders;
using MediatR;

namespace LojaOnline.Application.Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<OrderDto>>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper)
        {
            _orderReadRepository = orderReadRepository;
            _mapper = mapper;
        }

        public async Task<Result<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderReadRepository.GetByIdAsync(request.OrderId);
            if (order == null)
                return Result<OrderDto>.Failure("Order not found");

            var orderDto = _mapper.Map<OrderDto>(order);
            return Result<OrderDto>.Success(orderDto);
        }
    }
}
