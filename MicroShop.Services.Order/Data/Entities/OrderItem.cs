using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Core.Entities;

namespace MicroShop.Services.Order.Data.Entities
{
    public class OrderItem : IEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
