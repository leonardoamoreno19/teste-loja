using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Order.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Orders;
using MediatR;

namespace LojaOnline.Application.Order.Queries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, Result<List<OrderDto>>>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper)
        {
            _orderReadRepository = orderReadRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var orders = await _orderReadRepository.GetAllAsync();
            var orderDtos = _mapper.Map<List<OrderDto>>(orders);
            return Result<List<OrderDto>>.Success(orderDtos);
        }
    }
}
