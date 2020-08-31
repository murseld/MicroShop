using System;
using MediatR;
using MicroShop.Core.Bus;
using MicroShop.Core.Domain.Messages;

namespace MicroShop.Services.Product.Domain.Commands
{
    public class CreateProductCommand: IRequest<bool>, ICommand
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreateDate { get; }
        public CreateProductCommand(string name, decimal price, int quantity, ICorrelationContext context)
        {
            Id = Guid.NewGuid();
            ProductId = Guid.NewGuid();
            Name = name;
            Price = price;
            Quantity = quantity;
            CreateDate = DateTime.Now;

            CorrelationContext = context;
        }

        public ICorrelationContext CorrelationContext { get; set; }
    }
}
