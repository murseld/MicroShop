using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShop.Services.Basket.Data.Dtos
{
    public class BasketItemDto
    {
        public Guid BasketId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
