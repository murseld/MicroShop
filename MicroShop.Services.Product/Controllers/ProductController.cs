using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MicroShop.Core.Bus;
using MicroShop.Services.Product.Data.Dtos;
using MicroShop.Services.Product.Domain.Commands;
using MicroShop.Services.Product.Domain.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Services.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        private readonly IMediator _mediator;
        public ProductController(IBusPublisher busPublisher, IMediator mediator) : base(busPublisher)
        {
            _mediator = mediator;
        }
        // GET: api/Customer
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var productList = await _mediator.Send(new GetProductListQuery());
            return Ok(productList);
        }

        // GET: api/Customer
        [HttpGet("{productId}", Name = "Get")]
        public async Task<ActionResult> Get(Guid productId)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(productId));
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> Post(ProductDto product)
        {
            var context = GetContext();
            await _mediator.Send(new
                CreateProductCommand(product.Name, product.Price, product.Quantity,context));
            return Accepted();
        }

        [HttpPut]
        public async Task<ActionResult> Put(ProductDto product)
        {
            var context = GetContext();
            await _mediator.Send(new
                ProductChangeCommand(product.ProductId,product.Name, product.Price, product.Quantity,context));
            return Accepted();
        }
    }
}
