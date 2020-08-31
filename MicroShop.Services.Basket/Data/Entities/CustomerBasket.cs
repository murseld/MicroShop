using System;
using System.Collections.Generic;
using MicroShop.Core.Entities;

namespace MicroShop.Services.Basket.Data.Entities
{
    public class CustomerBasket:IEntity
    {
        public Guid BasketId { get; set; }
        public Guid CustomerId { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}
