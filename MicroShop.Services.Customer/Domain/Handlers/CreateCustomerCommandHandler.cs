
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MicroShop.Core.Bus;
using MicroShop.Core.Domain.MessagesHandlers;
using MicroShop.Services.Customer.Data.Dtos;
using MicroShop.Services.Customer.Domain.Commands;
using MicroShop.Services.Customer.Repositories;

namespace MicroShop.Services.Customer.Domain.Handlers
{
    public class CreateCustomerCommandHandler: IRequestHandler<CreateCustomerCommand,bool>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IBusPublisher _busPublisher;
        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IBusPublisher busPublisher)
        {
            _customerRepository = customerRepository;
            _busPublisher = busPublisher;
        }
    
        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new CustomerDto()
            {
                Id = request.Id,
                Email = request.Email,
                Address = request.Address,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
            };
            await _customerRepository.CreateCustomerAsync(customer);
            return Task.CompletedTask.IsCompleted;
        }
    }
}
