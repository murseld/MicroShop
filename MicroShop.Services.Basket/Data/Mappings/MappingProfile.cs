using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroShop.Services.Basket.Data.Dtos;

namespace MicroShop.Services.Basket.Data.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.CustomerBasket, CustomerBasketDto>().
                ForMember(dest => dest.Items, opt =>
                    opt.MapFrom(src => src.Items)).ReverseMap();
        }
    }
}
