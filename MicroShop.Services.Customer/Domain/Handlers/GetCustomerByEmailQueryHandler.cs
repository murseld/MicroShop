using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MicroShop.Core.Domain.MessagesHandlers;
using MicroShop.Services.Customer.Data.Dtos;
using MicroShop.Services.Customer.Domain.Queries;
using MicroShop.Services.Customer.Repositories;

namespace MicroShop.Services.Customer.Domain.Handlers
{
    public class GetCustomerByEmailQueryHandler: IRequestHandler<GetCustomerByEmailQuery, CustomerDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public GetCustomerByEmailQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<CustomerDto> Handle(GetCustomerByEmailQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByEmailAsync(request.Email);
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return customerDto;
        }
    }
}
