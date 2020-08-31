using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroShop.Core.Bus;
using MicroShop.Services.Product.Data.Dtos;
using MicroShop.Services.Product.Domain.Commands;
using MicroShop.Services.Product.Domain.Events;
using MicroShop.Services.Product.Repositories;

namespace MicroShop.Services.Product.Domain.Handlers
{
    public class ProductChangeCommandHandler : IRequestHandler<ProductChangeCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IBusPublisher _busPublisher;
        public ProductChangeCommandHandler(IProductRepository productRepository, IMapper mapper, IBusPublisher busPublisher)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _busPublisher = busPublisher;
        }
        public async Task<bool> Handle(ProductChangeCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductDto>(request);
            if (product != null)
            {
                await _productRepository.UpdateProductAsync(product);

                await _busPublisher.PublishAsync(new ProductChangedEvent(request.ProductId, request.Name, request.Price,
                    request.Quantity),request.CorrelationContext);

                return Task.CompletedTask.IsCompletedSuccessfully;
            }




            return Task.CompletedTask.IsFaulted;
        }
    }
}
