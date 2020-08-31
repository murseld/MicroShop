﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MicroShop.Core.Domain.Messages;
using MicroShop.Services.Product.Data.Dtos;

namespace MicroShop.Services.Product.Domain.Queries
{
    public class GetProductListQuery : IRequest<List<ProductDto>>
    {
        public GetProductListQuery()
        {
            
        }
    }
}
