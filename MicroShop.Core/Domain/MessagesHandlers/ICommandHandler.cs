using System.Threading.Tasks;
using MicroShop.Core.Bus;
using MicroShop.Core.Domain.Messages;

namespace MicroShop.Core.Domain.MessagesHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}
