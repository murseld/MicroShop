using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroShop.Services.Customer.Data.Dtos;
using MicroShop.Services.Customer.Domain.Queries;
using MicroShop.Services.Customer.Repositories;

namespace MicroShop.Services.Customer.Domain.Handlers
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetCustomerByIdAsync(request.CustomerId);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }
    }
}
