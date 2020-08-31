using System;
using MicroShop.Core.Entities;

namespace MicroShop.Services.Product.Data.Entities
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
       
        
    }
}
