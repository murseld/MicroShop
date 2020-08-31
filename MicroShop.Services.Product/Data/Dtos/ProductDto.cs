using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Core.Entities;

namespace MicroShop.Services.Product.Data.Dtos
{
    public class ProductDto:IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
    }
}
