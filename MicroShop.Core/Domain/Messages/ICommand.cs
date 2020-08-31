using MicroShop.Core.Bus;

namespace MicroShop.Core.Domain.Messages
{
    public interface ICommand
    {
        public ICorrelationContext CorrelationContext { get; set; }
        
    }
}
