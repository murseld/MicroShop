using System.Threading.Tasks;
using MicroShop.Core.Bus;
using MicroShop.Core.Domain.Messages;

namespace MicroShop.Core.Domain.MessagesHandlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent _event, ICorrelationContext context);
    }
}
