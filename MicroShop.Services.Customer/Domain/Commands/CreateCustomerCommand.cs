using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MicroShop.Core.Domain.Messages;

namespace MicroShop.Services.Customer.Domain.Commands
{
    public class CreateCustomerCommand : IRequest<bool>
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
    }
}
