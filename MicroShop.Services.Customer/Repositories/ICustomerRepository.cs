
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MicroShop.Services.Customer.Data.Dtos;

namespace MicroShop.Services.Customer.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerDto> GetCustomerByIdAsync(Guid customerId);
        Task<CustomerDto> GetByEmailAsync(string email);
        Task<List<CustomerDto>> GetListAsync();


        Task CreateCustomerAsync(CustomerDto customerCommand);

    }
}
