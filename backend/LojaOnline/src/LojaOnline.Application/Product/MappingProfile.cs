using AutoMapper;
using LojaOnline.Application.Product.Dtos;

namespace LojaOnline.Application.Product
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>();
        }
    }
}
