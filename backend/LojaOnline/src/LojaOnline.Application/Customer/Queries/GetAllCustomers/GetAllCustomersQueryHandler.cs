using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Customer.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Customers;

namespace LojaOnline.Application.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery, Result<List<CustomerDto>>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Result<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = await _customerRepository.GetAllAsync();
                var customerDtos = _mapper.Map<List<CustomerDto>>(customers);
                return Result<List<CustomerDto>>.Success(customerDtos);
            }
            catch (Exception ex)
            {
                return Result<List<CustomerDto>>.Failure(ex.Message);
            }
        }
    }
}
