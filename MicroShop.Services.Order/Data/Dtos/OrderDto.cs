using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Core.Entities;
using MicroShop.Services.Order.Data.Entities;

namespace MicroShop.Services.Order.Data.Dtos
{
    public class OrderDto : IEntity
    {
        public Guid CustomerId { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
    }

  
}
