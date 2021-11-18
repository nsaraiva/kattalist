using AutoMapper;
using Kattalist.Domain.DTOs;
using Kattalist.Domain.Entities;

namespace Kattalist.Domain.Entities
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ListaCompras, ListaComprasDTO>()
                .ReverseMap();
        }
    }
}