using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Customer.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Customers;
using MediatR;

namespace LojaOnline.Application.Customer.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Result<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Result<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
            if (customer == null)
                return Result<CustomerDto>.Failure("Customer not found");

            var customerDto = _mapper.Map<CustomerDto>(customer);
            return Result<CustomerDto>.Success(customerDto);
        }
    }
}
