using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroShop.Services.Customer.Data;
using MicroShop.Services.Customer.Data.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MicroShop.Services.Customer.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;
        private readonly IMapper _mapper;

        public CustomerRepository(CustomerDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        #region Queries

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid customerId)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(p => p.CustomerId == customerId);
            return _mapper.Map<CustomerDto>(customer);
        }
      
        public async Task<CustomerDto> GetByEmailAsync(string email)
        {
            var customer= await _dbContext.Customers.FirstOrDefaultAsync(p => p.Email == email);
            return _mapper.Map<CustomerDto>(customer);
        }

        public async Task<List<CustomerDto>> GetListAsync()
        {
            var customerList= await _dbContext.Customers.ToListAsync();
            return _mapper.Map<List<CustomerDto>>(customerList);
        }

        #endregion

        #region Commands

        public async Task CreateCustomerAsync(CustomerDto customerCommand)
        {
            var customer = _mapper.Map<Data.Entities.Customer>(customerCommand);
            await _dbContext.Customers.AddAsync(customer);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
