using AutoMapper;
using LojaOnline.Application.Customer.Dtos;

namespace LojaOnline.Application.Customer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Customer, CustomerDto>();
        }
    }
}
