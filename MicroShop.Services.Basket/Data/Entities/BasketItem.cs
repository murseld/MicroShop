using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MicroShop.Core.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace MicroShop.Services.Basket.Data.Entities
{
    public class BasketItem:IEntity
    {
        [BsonId]
        public Guid BasketItemId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal OldUnitPrice { get; set; }
        public int Quantity { get; set; }
        
    }
}
