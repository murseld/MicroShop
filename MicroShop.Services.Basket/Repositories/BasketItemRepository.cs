using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MicroShop.Services.Basket.Data.Dtos;
using MicroShop.Services.Basket.Data.Entities;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace MicroShop.Services.Basket.Repositories
{
    public class BasketItemRepository:IBasketItemRepository
    {
        private readonly IMongoDatabase _database;
        private readonly IMapper _mapper;
        public BasketItemRepository(IMongoDatabase database, IMapper mapper)
        {
            _database = database;
            _mapper = mapper;
        }

        private IMongoCollection<BasketItem> Collection
        {
            get
            {
                return _database.GetCollection<BasketItem>("BasketItem");
            }
        }

        public async Task<List<BasketItemDto>> GetBasketItemByProductIdAsync(Guid productId)
        {
            var basket= await Collection
                .AsQueryable()
                .Where(x => x.ProductId == productId).ToListAsync();
            var basketItemDto = _mapper.Map<List<BasketItemDto>>(basket);
            return basketItemDto;
        }

        public async Task<BasketItemDto> GetBasketItemByIdAsync(Guid basketId)
        {
            var basketItem= await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.BasketItemId == basketId);
            var basketItemDto=_mapper.Map<BasketItemDto>(basketItem);
            return basketItemDto;
        }

        public Task AddAsync(BasketItemDto basket)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(BasketItemDto basket)
        {
           var filter = Builders<BasketItem>.Filter.Eq("productId", basket.ProductId);
            var update = Builders<BasketItem>.Update
                .Set("productName", basket.ProductName)
                .Set("quantity", basket.Quantity)
                .Set("unitPrice", basket.UnitPrice);
            await Collection.UpdateOneAsync(filter, update);
        }
    }
}
