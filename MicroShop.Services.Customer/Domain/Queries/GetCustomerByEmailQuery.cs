using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MicroShop.Core.Domain.Messages;
using MicroShop.Services.Customer.Data.Dtos;

namespace MicroShop.Services.Customer.Domain.Queries
{
    public class GetCustomerByEmailQuery: IRequest<CustomerDto>
    {
        public string Email { get; set; }

        public GetCustomerByEmailQuery(string email)
        {
            Email = email;
        }
    }
}
