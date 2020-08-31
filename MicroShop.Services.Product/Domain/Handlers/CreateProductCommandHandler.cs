using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroShop.Core.Bus;
using MicroShop.Core.Domain.MessagesHandlers;
using MicroShop.Services.Product.Data.Dtos;
using MicroShop.Services.Product.Domain.Commands;
using MicroShop.Services.Product.Repositories;
using MicroShop.Services.Product.UnitOfWorks;
using Microsoft.Extensions.Logging;

namespace MicroShop.Services.Product.Domain.Handlers
{
    public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateProductCommandHandler> _logger;
        public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IUnitOfWork unitOfWork, ILogger<CreateProductCommandHandler> logger)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<ProductDto>(request);
            await _productRepository.CreateProductAsync(product);
            _logger.LogInformation($"[Local Transaction] : Product '{request.ProductId}' not found. CorrelationId: {request.CorrelationContext.CorrelationId}");

            _unitOfWork.SaveChanges();

            return Task.CompletedTask.IsCompletedSuccessfully;
        }

       
    }
}
