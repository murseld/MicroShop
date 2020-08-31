using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Services.Order.Data;
using MicroShop.Services.Order.Data.Dtos;

namespace MicroShop.Services.Order.Repositories
{
    public class OrderRepository:IOrderRepository
    {
        private OrderDbContext _dbContext;
        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<OrderDto> GetOrderByIdAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetOrderByCustomerAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
