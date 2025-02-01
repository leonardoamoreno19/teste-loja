using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using LojaOnline.Application.Customer.Dtos;
using LojaOnline.Application.Shared;
using LojaOnline.Domain.Customers;
using MediatR;

namespace LojaOnline.Application.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Result<CustomerDto>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<Result<CustomerDto>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(request.Id);
                if (customer == null)
                    return Result<CustomerDto>.Failure("Customer not found");

                if (!string.Equals(customer.Email, request.Email) && !await _customerRepository.IsEmailUniqueAsync(request.Email))
                    return Result<CustomerDto>.Failure("Email must be unique");

                customer.Update(request.Name, request.Email, request.Phone);
                await _customerRepository.UpdateAsync(customer);
                await _customerRepository.SaveChangesAsync();

                var customerDto = _mapper.Map<CustomerDto>(customer);
                return Result<CustomerDto>.Success(customerDto);
            }
            catch (Exception ex)
            {
                return Result<CustomerDto>.Failure($"Error updating customer: {ex.Message}");
            }
        }
    }
}
