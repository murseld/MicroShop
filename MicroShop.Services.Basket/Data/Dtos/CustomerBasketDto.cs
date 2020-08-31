using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroShop.Services.Basket.Data.Dtos
{
    public class CustomerBasketDto
    {
        public Guid BasketId { get; set; }
        public Guid CustomerId { get; set; }
        public List<BasketItemDto> Items { get; set; }
    }
}
