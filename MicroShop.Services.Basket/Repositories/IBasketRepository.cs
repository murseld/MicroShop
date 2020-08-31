using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MicroShop.Services.Basket.Data.Dtos;

namespace MicroShop.Services.Basket.Repositories
{
    public interface IBasketRepository
    {
        Task<List<CustomerBasketDto>> GetBasketByCustomerAsync(Guid customerId);
        Task<CustomerBasketDto> GetBasketByIdAsync(Guid basketId);

        Task AddAsync(CustomerBasketDto basket);
        
    }
}
