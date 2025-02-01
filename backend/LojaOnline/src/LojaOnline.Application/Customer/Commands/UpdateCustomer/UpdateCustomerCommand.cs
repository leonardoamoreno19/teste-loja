using LojaOnline.Application.Customer.Dtos;
using LojaOnline.Application.Shared;

namespace LojaOnline.Application.Customer.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : ICommand<Result<CustomerDto>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
