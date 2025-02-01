using AutoMapper;
using LojaOnline.Application.Order.Dtos;
using LojaOnline.Domain.Entities;
using LojaOnline.Domain.Orders;

namespace LojaOnline.Application.Order
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Order, OrderDto>()
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.Customer.Name));

            CreateMap<OrderItem, OrderItemDto>();

            // Mapeamento do modelo de leitura
            CreateMap<OrderReadModel, OrderDto>()
                .ForMember(d => d.CustomerName, opt => opt.MapFrom(s => s.CustomerName));

            CreateMap<OrderItemReadModel, OrderItemDto>();
        }
    }
}
