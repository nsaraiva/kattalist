using AutoMapper;
using Kattalist.Domain.Entities;

namespace Kattalist.Domain.Entities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ListaCompras, ListaComprasDTO>()
                .ReverseMap();
                //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Name));
            //    .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
            //    .ReverseMap();
            //var config = new MapperConfiguration(cfg =>
            //        cfg.CreateMap<ListaCompras, ListaComprasDTO>()
            //    );
        }
    }
}