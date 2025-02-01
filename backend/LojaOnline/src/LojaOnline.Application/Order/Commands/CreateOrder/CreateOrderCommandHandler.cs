using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Order.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Customers;
using LojaOnline.Domain.Orders;
using LojaOnline.Domain.Products;
using MediatR;

namespace LojaOnline.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Result<OrderDto>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
                if (customer == null)
                    return Result<OrderDto>.Failure("Customer not found");

                var order = new Domain.Entities.Order(request.CustomerId, DateTime.UtcNow);

                foreach (var item in request.Items)
                {
                    var product = await _productRepository.GetByIdAsync(item.ProductId);
                    if (product == null)
                        return Result<OrderDto>.Failure($"Product with id {item.ProductId} not found");

                    var orderItem = new Domain.Entities.OrderItem(
                        item.ProductId,
                        product.Name,
                        item.Quantity,
                        product.Price);

                    order.AddItem(orderItem);
                }

                await _orderRepository.AddAsync(order);
                await _orderRepository.SaveChangesAsync();

                var orderDto = _mapper.Map<OrderDto>(order);
                return Result<OrderDto>.Success(orderDto);
            }
            catch (Exception ex)
            {
                return Result<OrderDto>.Failure($"Error creating order: {ex.Message}");
            }
        }
    }
}
