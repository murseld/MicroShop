using System;
using MicroShop.Core.Entities;

namespace MicroShop.Services.Customer.Data.Entities
{
    public class Customer : IEntity
    {
        public Guid CustomerId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
    }
}
