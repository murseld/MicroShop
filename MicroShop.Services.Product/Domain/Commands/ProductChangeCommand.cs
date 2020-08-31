using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MicroShop.Core.Bus;

namespace MicroShop.Services.Product.Domain.Commands
{
    public class ProductChangeCommand:IRequest<bool>
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public ProductChangeCommand(Guid productId,string name, decimal price, int quantity,ICorrelationContext context)
        {
            ProductId = productId;
            Name = name;
            Price = price;
            Quantity = quantity;

            CorrelationContext = context;
        }

        public ICorrelationContext CorrelationContext { get; set; }
    }
}
