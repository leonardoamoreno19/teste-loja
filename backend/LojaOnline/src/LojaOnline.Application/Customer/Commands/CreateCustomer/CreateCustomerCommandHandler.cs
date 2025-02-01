using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Customer.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Customers;
using LojaOnline.Domain.Products;

namespace LojaOnline.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Result<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Result<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = new Domain.Entities.Customer(request.Name, request.Email, request.Phone);
                await _customerRepository.AddAsync(customer);
                await _customerRepository.SaveChangesAsync();

                var customerDto = _mapper.Map<CustomerDto>(customer);
                return Result<CustomerDto>.Success(customerDto);
            }
            catch (Exception ex)
            {
                return Result<CustomerDto>.Failure(ex.Message);
            }
        }
    }
}
