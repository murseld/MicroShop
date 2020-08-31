using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.ApiGateway.Domains.Commands;
using MicroShop.Core.Bus;
using Microsoft.AspNetCore.Mvc;

namespace MicroShop.ApiGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseController
    {

        public CustomerController(IBusPublisher busPublisher) : base(busPublisher)
        {

        }


        // POST: api/Customer
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerCommand customer)
        {
            var context = GetContext(customer.Id);
            await BusPublisher.SendAsync(customer, context);
            return Accepted();
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    
    }
}
