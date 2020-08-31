using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroShop.Core.Domain.MessagesHandlers;
using MicroShop.Services.Product.Data.Dtos;
using MicroShop.Services.Product.Domain.Queries;
using MicroShop.Services.Product.Repositories;

namespace MicroShop.Services.Product.Domain.Handlers
{
    public class GetProductListQueryHandler : IRequestHandler<GetProductListQuery, List<ProductDto>>
    {
        private IProductRepository _productRepository;

        public GetProductListQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductListAsync();
        }
    }
}
