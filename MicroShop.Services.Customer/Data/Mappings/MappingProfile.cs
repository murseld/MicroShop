using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroShop.Services.Customer.Data.Dtos;

namespace MicroShop.Services.Customer.Data.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            //Complex to Flattened
            CreateMap<Entities.Customer, CustomerDto>().ReverseMap();
        }
    }
}
