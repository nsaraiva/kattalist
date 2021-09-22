using AutoMapper;
using Kattalist.Domain.Entities;

namespace automapper_sample
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ListaCompras, ListaComprasDTO>());
            //CreateMap<ListaComprasDTO, ListaCompras>();
            //.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //.ReverseMap();
        }
    }
}