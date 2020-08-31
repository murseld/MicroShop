using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroShop.Core.Bus;
using MicroShop.Core.Data;
using MicroShop.Core.Domain.MessagesHandlers;
using MicroShop.Services.Basket.Domain.Events;
using MicroShop.Services.Basket.Repositories;

namespace MicroShop.Services.Basket.Domain.Handlers
{
    public class ProductChangedEventHandler: IEventHandler<ProductChangedEvent>
    {
        private readonly IBasketRepository _basketRepository;

        public ProductChangedEventHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task HandleAsync(ProductChangedEvent _event, ICorrelationContext context)
        {
            await _basketRepository.AddAsync(null);
            //Console.WriteLine($"{_event}");
        }
    }
}
