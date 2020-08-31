using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroShop.Services.Product.Data.Dtos;
using MicroShop.Services.Product.Domain.Commands;

namespace MicroShop.Services.Product.Data.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.Product, ProductDto>().ReverseMap();
            CreateMap<CreateProductCommand, ProductDto>().ReverseMap();
            CreateMap<ProductChangeCommand, ProductDto>().ReverseMap();
        }
    }
}
