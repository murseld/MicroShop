using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroShop.Core.Bus;
using MicroShop.Core.Domain.Messages;
using MicroShop.Core.Domain.MessagesHandlers;
using MicroShop.Services.Product.Data.Dtos;
using MicroShop.Services.Product.Domain.Queries;
using MicroShop.Services.Product.Repositories;

namespace MicroShop.Services.Product.Domain.Handlers
{
    //public interface IRequestCorrelationHandler<TRequest, TCorrelation>
    //where TRequest:ICommand
    //where TCorrelation : ICorrelationContext
    //{

    //}
    public class GetProductByIdQueryHandler: IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.ProductId);
            return product;
        }
    }
}
