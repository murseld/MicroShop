using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Services.Basket.Data.Dtos;

namespace MicroShop.Services.Basket.Repositories
{
    public interface IBasketItemRepository
    {
        Task<List<BasketItemDto>> GetBasketItemByProductIdAsync(Guid productId);
        Task<BasketItemDto> GetBasketItemByIdAsync(Guid basketId);

        Task AddAsync(BasketItemDto basket);
        Task UpdateAsync(BasketItemDto basket);

    }

    
}
