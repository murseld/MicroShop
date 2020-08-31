using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Services.Order.Data.Dtos;

namespace MicroShop.Services.Order.Repositories
{
    public interface IOrderRepository
    {
        Task<OrderDto> GetOrderByIdAsync(Guid orderId);
        Task<OrderDto> GetOrderByCustomerAsync(Guid customerId);


        //Task CreateOrder
    }
}
