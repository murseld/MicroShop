using MicroShop.Core.Domain.Messages;

namespace MicroShop.Core.Bus
{
    public interface IBusSubscriber
    {
        IBusSubscriber SubscribeCommand<TCommand>(string _namespace = null)
            where TCommand : ICommand;

        IBusSubscriber SubscribeEvent<TEvent>(string _namespace = null)
            where TEvent : IEvent;
    }
}
