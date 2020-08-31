using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Core.Bus;
using MicroShop.Core.Domain.Messages;

namespace MicroShop.Services.Product.Domain.Events
{
    [MessageNamespace("Basket")]
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
