using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MicroShop.Services.Basket.Data.Dtos;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace MicroShop.Services.Basket.Repositories
{
    public class BasketRepository:IBasketRepository
    {
        private readonly IMongoDatabase _database;
        public BasketRepository(IMongoDatabase database)
        {
            _database = database;
        }

        private IMongoCollection<CustomerBasketDto> Collection => _database.GetCollection<CustomerBasketDto>("BasketItem");

        public async Task<List<CustomerBasketDto>> GetBasketByCustomerAsync(Guid customerId)
            => await Collection
                .AsQueryable()
                .Where(x => x.CustomerId == customerId).ToListAsync();

        public async Task<CustomerBasketDto> GetBasketByIdAsync(Guid basketId)
        {
            return await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.BasketId == basketId);
        }

        

        public Task AddAsync(CustomerBasketDto basket)
        {
            throw new NotImplementedException();
        }

        //public async Task<List<BasketDto>> GetListAsync(Expression<Func<BasketDto, bool>> filter)
        //    => await Collection
        //        .AsQueryable().Where(filter).ToListAsync();

        //public async Task AddAsync(BasketDto basket)
        //{
        //    var productInBasket = await GetAsync(basket.Items);
        //    if (productInBasket == null)
        //    {
        //        await Collection.InsertOneAsync(basket);
        //    }
        //    else
        //    {
        //        productInBasket.Quantity++;
        //        await UpdateAsync(productInBasket);
        //    }
        //}


       
    }
}
