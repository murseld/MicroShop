using System;
using System.Threading.Tasks;
using MediatR;
using MicroShop.Services.Customer.Domain.Commands;
using MicroShop.Services.Customer.Domain.Queries;
using MicroShop.Services.Customer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.Services.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Customer 
        [HttpGet("{customerId}", Name = "Get")]
        public async Task<ActionResult> Get(Guid customerId)
        {
            var customer = await _mediator.Send(new GetCustomerByIdQuery(customerId));
            return Ok(customer);
        }

        // GET: api/Customer
        [HttpGet("{email}", Name = "Get")]
        public async Task<ActionResult> Get(string email)
        {
            var customer = await _mediator.Send(new GetCustomerByEmailQuery(email));
            return Ok(customer);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand customer)
        {
            //var context = GetContext(customer.Id);
            await _mediator.Send(customer);
            return Accepted();
        }


    }
}
