using System;
using MicroShop.Core.Domain.Messages;

namespace MicroShop.Services.Basket.Domain.Events
{
    
    public class ProductChangedEvent : IEvent
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ProductChangedEvent(Guid productId, string name, decimal price, int quantity)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Quantity = quantity;
        }

    }
}
