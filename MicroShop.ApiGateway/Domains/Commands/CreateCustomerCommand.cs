using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Core.Bus;
using MicroShop.Core.Domain.Messages;
using Newtonsoft.Json;

namespace MicroShop.ApiGateway.Domains.Commands
{
    [MessageNamespace("Customer")]
    public class CreateCustomerCommand : ICommand
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }


        public CreateCustomerCommand(string email, string password, string firstName, string lastName, string address)
        {
            Id = Guid.NewGuid();
            CustomerId = Guid.NewGuid();
            Password = password;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public ICorrelationContext CorrelationContext { get; set; }
    }
}
