using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroShop.Services.Order.Data.Dtos;

namespace MicroShop.Services.Order.Data.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Order, OrderDto>().
                ForMember(dest => dest.Items, opt =>
                opt.MapFrom(src => src.Items)).ReverseMap();
        }
    }
}
