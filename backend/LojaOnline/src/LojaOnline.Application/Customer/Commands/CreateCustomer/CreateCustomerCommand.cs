using LojaOnline.Application.Customer.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICommand<Result<CustomerDto>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
